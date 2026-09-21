---
title: Szövegmezők kezelése PowerPoint-prezentációkban .NET-ben
linktitle: Szövegmezők
type: docs
weight: 52
url: /hu/net/text-fields/
keywords:
- szövegmező
- automatikus szöveg
- diaszám
- dátum és idő
- fejléc
- lábléc
- szövegrész
- PowerPoint
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Hozzon létre, vizsgáljon, módosítson és távolítson el szövegmezőket PowerPoint-prezentációkban az Aspose.Slides for .NET használatával. Őrizze a formázást és ellenőrizze a mentett PPTX és PPT fájlokat."
---
## **Áttekintés**

Egy szöveges bekezdés részekből áll. Egy szokásos [IPortion](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/) literális szöveget tartalmaz; egy mezőrésznek van egy [IField](https://reference.aspose.com/slides/hu/net/aspose.slides/ifield/) , amelynek típusa egy automatikusan frissülő értéket azonosít, például diaszámot vagy dátumot. Két rész is megjelenítheti ugyanazokat a karaktereket, míg csak az egyik tartalmaz mezőt.

Használd a [IPortion.Field](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/field/) a megkülönböztetéshez: szokásos szöveg esetén `null`. Az [IPortion.AddField](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/addfield/) egy meglévő részt mezővé konvertál. Tartsd a címkét és a dinamikus értékét külön részekben, hogy az érték konvertálása ne cserélje le a címkét is.

Ez az útmutató a szövegen belüli mezőket, azok formázását és PPTX illetve PPT formátumba mentését tárgyalja. A szövegdobozokkal és bekezdésekkel kapcsolatban lásd a [Szöveg kezelése](/slides/hu/net/manage-text/) oldalt.

## **Diaszám mező létrehozása**

A következő teljes példa egy szövegdobozt hoz létre, amely egy literális `Slide ` címkét tartalmaz, amelyet egy automatikusan frissülő szám követ. A szám méretét, vastagságát és színét a mező hozzáadása előtt állítja be, majd újra megnyitja a mentett prezentációt, és ellenőrzi a mező típusát, a szöveget és a formázást. Bemeneti fájl nem szükséges.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

Az új prezentáció az 1. diaszámmal kezdődik, így a szöveg `Slide 1`, és mindkét ellenőrzés `True` értéket ad. A szám a megnyitás után is mező marad; nem egy literális `1`. A verifikációban szereplő átalakítások és indexek az ebben a példában létrehozott alakzatot és részeket jelölik.

## **Mező típus kiválasztása**

A [FieldType](https://reference.aspose.com/slides/hu/net/aspose.slides/fieldtype/) megvalósítja az [IFieldType](https://reference.aspose.com/slides/hu/net/aspose.slides/ifieldtype/) interfészt, és a következő előre definiált értékeket biztosítja. A megfelelő értéket add át az [AddField](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/addfield/) metódusnak.

| Érték | Cél |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/hu/net/aspose.slides/fieldtype/slidenumber/) | Az aktuális diaszám. |
| [DateTime](https://reference.aspose.com/slides/hu/net/aspose.slides/fieldtype/datetime/) | Dátum/idő a megjelenítő alkalmazás alapértelmezett formátumában. |
| [DateTime1](https://reference.aspose.com/slides/hu/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/hu/net/aspose.slides/fieldtype/datetime9/) | Előre definiált dátum vagy kombinált dátum/idő formátumok. |
| [DateTime10](https://reference.aspose.com/slides/hu/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/hu/net/aspose.slides/fieldtype/datetime13/) | Előre definiált időformátumok, másodpercek és 12 órás óra opciókkal. |
| [Header](https://reference.aspose.com/slides/hu/net/aspose.slides/fieldtype/header/) | Fejléc mező; lásd alább a helyőrző és formátum korlátozások. |
| [Footer](https://reference.aspose.com/slides/hu/net/aspose.slides/fieldtype/footer/) | Lábléc mező. |

Például a [DateTime3](https://reference.aspose.com/slides/hu/net/aspose.slides/fieldtype/datetime3/) egy napot, a teljes hónap nevét és az évet angolul jelöli. Ezek előre definiált mezőformátumok, nem önkényes .NET dátumformátum karakterláncok. A rész [LanguageId](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/languageid/) és a prezentációt feldolgozó alkalmazás befolyásolhatja a megjelenített eredményt.

## **Mező létrehozása belső karakterláncból**

A [AddField](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/addfield/) karakterlánc túlterhelése egy belső mezőazonosítót fogad el. Használd, ha egy másik alkalmazás által biztosított, előre definiált érték nélküli azonosítót szeretnéd megőrizni. A [FieldType](https://reference.aspose.com/slides/hu/net/aspose.slides/fieldtype/fieldtype/) is felépíthető az azonosítóból. Az [IFieldType.InternalString](https://reference.aspose.com/slides/hu/net/aspose.slides/ifieldtype/internalstring/) ezt az azonosítót teszi láthatóvá vizsgálathoz.

Ez a példa egy alkalmazás-specifikus `custom-report-id` mezőt tárol a tartalék szöveggel `Report-042`. Az azonosító nem regisztrál számítást: az Aspose.Slides nem generál jelentésazonosítókat ismeretlen típushoz. Az azonosítót értő alkalmazásnak kell biztosítania a jelentését és frissítenie az értékét.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

Az ezt követő PPTX körutazás után a típus `custom-report-id` és a szöveg `Report-042`. Egy `yyyy-MM-dd` karakterlánc átadása mező típust nevezne; nem állít be egyedi dátumformátumot. Egy rögzített dátumhoz tetszőleges formátumban használj szokásos szöveget.

## **Dátum/Idő mezők vizsgálata, módosítása és eltávolítása**

Egy meglévő mezőt a [IField.Type](https://reference.aspose.com/slides/hu/net/aspose.slides/ifield/type/) segítségével olvashatod és módosíthatod. Ellenőrizd, hogy a mező létezik-e, mielőtt hozzáférnél a típusához. Az automatikus frissítések leállításához hívd a [IPortion.RemoveField](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/removefield/) metódust. Ez megtartja a részt és a jelenlegi szöveget, miközben eltávolítja a mezőkapcsolatot. Ha egy konkrét rögzített értékre van szükség, a mező eltávolítása után állítsd be azt a szöveget.

A dátum/idő mező feldolgozásához kapcsolódó API beállításhoz lásd a [Presentation.CurrentDateTime](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/currentdatetime/). Az alábbi példa egy kifejezett jóváhagyási dátumot használ, amikor egy mezőt szokásos szöveggé konvertál.

Töltsd le a [sample.pptx](sample.pptx) fájlt, és helyezd a munkakönyvtárba. Két névvel ellátott szöveges alakzatot tartalmaz, `UpdatedAt` és `ApprovedDate`, mindkettő egy dátum/idő mezővel, plusz szokásos szövegcímkékkel. A következő példa a rendszeres diák felső szintű szövegalakzataiban jár. A dátum/idő mezőket hosszú dátumformátumra változtatja, és dőlté teszi őket, miközben megtartja a többi formázást. Csak a `ApprovedDate` mezők válnak rögzített szöveggé.

A minta felismeri a beépített belső azonosítókat `datetime` és `datetime1`‑től `datetime13`‑ig. A csoportok, táblázatok, jegyzetek, elrendezések és mesteroldalak saját szövegtárolóik bejárását igénylik, ez pedig kívül esik a példa hatókörén.

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

A megnyitás után az `UpdatedAt` típusa `datetime3`, és dinamikus marad. Az `ApprovedDate` nem tartalmaz mezőt, és a szövege `05 April 2030`. Mindkét dátum rész dőlt, eredeti betűmérete, félkövér beállítása és színe változatlan. A szokásos szövegcímkék nem változnak. A verifikáció a mintában megadott két ismert alakzat első részét olvassa.

## **Szövegformázás megőrzése**

Használd a meglévő részt mező hozzáadásakor, típusának módosításakor vagy eltávolításakor. Ezek a műveletek megtartják a rész formázását. Használd a [IPortion.PortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/portionformat/) csak a szükséges tulajdonságok módosításához, ahogy a példák a szín vagy dőlt esetén teszik.

Kerüld el egy teljes szövegdoboz újjáépítését csak egy mező frissítéséhez: ez elveszítheti az eredeti részhatárokat és azok egyedi formázását. Továbbá különböztesd a kifejezetten beállított formázást a bekezdésből, elrendezésből vagy témából örökölt formázástól. Lásd a [Text Formatting](/slides/hu/net/text-formatting/) oldalt a szélesebb formázási lehetőségekért.

## **Mezők és fejlécek/láblécek helyőrzői**

Egy mező a szövegrész része. Egy helyőrző egy alakzat, amely egy prezentációs szerepet tölt be, például lábléc vagy diaszám. Egy mező hozzáadása egy szokásos szövegdobozhoz nem változtatja azt helyőrzővé.

A fejlécek/láblécek kezelők szabályozzák a helyőrző szöveget és láthatóságot a diákon, elrendezéseken és mesteroldalakon, beleértve a függő diákra való terjesztést. Egy szám mező egy egyedi szövegdobozban hasznos lehet, még ha nem is használod a diaszám helyőrzőt. Fordítva, a helyőrző láthatóságának változtatása nem távolít el egy mezőt egy nem kapcsolódó szövegdobozból.

Az előre definiált fejléc és lábléc típusok nem hoznak létre a megfelelő helyőrzőket, és nem biztosítják azok tartalmát. Különösen, egy normál PowerPoint dia nem rendelkezik fejléc helyőrzővel; a fejlécek a jegyzetoldalakra és szórólapokra vonatkoznak. Ne feltételezd, hogy egy fejléc vagy lábléc mező egy tetszőleges alakzatban automatikusan megkapja a helyőrzőkezelőben beállított szöveget. Erről a munkafolyamatról lásd a [Presentation Headers and Footers](/slides/hu/net/presentation-header-and-footer/) oldalt.

## **PPTX és PPT korlátozások**

Ellenőrizd a mező típusát és a keletkezett szöveget a mentés és újranyitás után is. Az azonosító megőrzése nem bizonyítja, hogy az alkalmazás képes számítani vagy megjeleníteni az értékét.

| Formátum | Mező viselkedése és korlátozások |
|---|---|
| PPTX | Belső mezőazonosítókat tárol a mező szövege mellett. A körutazás ellenőrzéseknél az előre definiált típusok és a fent használt egyedi azonosító is megmaradt a mentés és újranyitás után. Az ismeretlen egyedi típus megtartotta a tartalék szöveget; nem kapott automatikus számítási logikát. Egy másik alkalmazás eltérően kezelheti a nem támogatott azonosítókat. |
| PPT | Örökölt mezőábrázolásokat használ, és korlátozottabb kompatibilitással rendelkezik. A körutazás ellenőrzéseknél a diaszám és az előre definiált dátum/idő mezők megmaradtak a mentés és újranyitás után. Egy egyedi mező egy szokásos diaszövegdobozban azonosítóval nyílt meg, de szövege `*` volt; egy fejléc mező ugyanabban a kontextusban szintén `*`-ot adott. Ne számíts egyedi mezőkre vagy nem támogatott mező kontextusokra, hogy megőrzik látható szövegüket.

Az hordozható, rögzített kimenethez konvertáld a nem támogatott mezőket szokásos szöveggé, és a mentés előtt állítsd be a kívánt értéket. Ez megőrzi a kiválasztott szöveget, de szándékosan leállítja az automatikus frissítéseket. Teszteld a célalkalmazást is, ha saját mező-újraszámítása a munkafolyamat része.

## **GYIK**

**Hogyan tudom megállapítani, hogy egy megjelenített szám vagy dátum mező-e?**

Ellenőrizd az [IPortion.Field](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/field/). A nem null érték egy mezőt azonosít; a megjelenített szöveg önmagában nem mondja meg.

**Eltávolítja a mező a szöveget vagy a formázást?**

Nem. A [RemoveField](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/removefield/) a meglévő részt szokásos szöveggé konvertálja. Adj meg egy explicit értéket utána, ha egy adott rögzített dátumra vagy tartalékértékre van szükség.

**Definiálhat-e egy belső karakterlánc új dátumformátumot vagy képletet?**

Nem. Egy azonosít egy mező típust. Egy ismeretlen azonosító nem biztosít kiértékelőt vagy .NET dátumformátum mintát. Használj támogatott előre definiált típust, vagy formázd a értéket saját magad szokásos szövegként.

**Miért ellenőrizd újra a prezentációt a mentés után?**

A mezőazonosítók, a számított szöveg és a formázás különálló ellenőrzési elemek. A formátum konverzió módosíthatja a látható eredményt még akkor is, ha a mezőazonosító továbbra is jelen van.