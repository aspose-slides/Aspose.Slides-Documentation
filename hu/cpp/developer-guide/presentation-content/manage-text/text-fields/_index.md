---
title: Szövegmezők kezelése PowerPoint‑prezentációkban C++‑ban
linktitle: Szövegmezők
type: docs
weight: 52
url: /hu/cpp/text-fields/
keywords:
- szövegmező
- automatikus szöveg
- dia száma
- dátum és idő
- fejléc
- lábléc
- szöverrész
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Szövegmezők létrehozása, ellenőrzése, módosítása és eltávolítása PowerPoint‑prezentációkban az Aspose.Slides for C++ segítségével. Formázás megőrzése és a mentett PPTX és PPT fájlok ellenőrzése."
---
## **Áttekintés**

Egy szöveges bekezdés részekből áll. Egy egyszerű [IPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/) literális szöveget tartalmaz; egy mező résznek emellett van egy [IField](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifield/) amelynek típusa egy automatikusan frissített értéket határoz meg, például egy dia számát vagy dátumot. Két rész ugyanazokat a karaktereket jelenítheti meg, miközben csak az egyik tartalmaz mezőt.

Használja az [IPortion::get_Field](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/get_field/) metódust a megkülönböztetéshez: egyszerű szöveg esetén `nullptr`-t ad vissza. Az [IPortion::AddField](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/addfield/) egy meglévő részt mezővé alakít. Tartsa a címkét és a dinamikus értékét külön részekben, hogy az érték mezővé alakítása ne cserélje le a címkét is.

Ez az útmutató a szövegben lévő mezőket, azok formázását és PPTX illetve PPT formátumban való mentését tárgyalja. A szövegkeretekkel és bekezdésekkel kapcsolatban lásd a [Manage Text](/slides/hu/cpp/manage-text/) oldalt.

## **Dia szám mező létrehozása**

Az alábbi példa egy szövegdobozt hoz létre, amely egy literális `Slide ` címkét és egy automatikusan frissített számot tartalmaz. A mező hozzáadása előtt beállítja a szám méretét, súlyát és színét, majd újra megnyitja a mentett prezentációt, és ellenőrzi a mező típusát, szövegét és formázását. Nem szükséges bemeneti fájl.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

Az új prezentáció az 1. diával indul, ezért a várt szöveg `Slide 1`, és mindkét ellenőrzésnek `True`‑t kell kiírnia. A szám újra megnyitás után is mező marad; nem egy egyszerű `1`. A verifikációban a konverziók és indexek a példában létrehozott alakzatot és részeket referálják.

## **Mezőtípus kiválasztása**

[FieldType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fieldtype/) implementálja a [IFieldType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifieldtype/) interfészt, és a következő előre definiált értékeket biztosítja. A megfelelő értéket adja át az [AddField](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/addfield/) metódusnak.

| Accessor | Purpose |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fieldtype/get_slidenumber/) | Az aktuális dia száma. |
| [get_DateTime](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fieldtype/get_datetime/) | Dátum/idő a megjelenítő alkalmazás alapértelmezett formátumában. |
| [get_DateTime1](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fieldtype/get_datetime9/) | Előre definiált dátum vagy kombinált dátum/idő formátumok. |
| [get_DateTime10](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fieldtype/get_datetime13/) | Előre definiált időformátumok, másodpercek és 12‑órás óra opciókkal. |
| [get_Header](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fieldtype/get_header/) | Fejlécmező; lásd a helyőrző és formátumkorlátozások alább. |
| [get_Footer](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fieldtype/get_footer/) | Láblécmező. |

Például a [get_DateTime3](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fieldtype/get_datetime3/) egy napot, a teljes hónap nevét és az évet adja vissza angolul. Ezek előre definiált mezőformátumok, nem tetszőleges dátumformátum‑karakterláncok. A rész nyelvét a [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_languageid/) metódussal lehet beállítani, és a prezentációt feldolgozó alkalmazás is befolyásolhatja a megjelenített eredményt.

## **Mező létrehozása belső karakterláncból**

Az [AddField](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/addfield/) karakterlánc‑túlterhelése egy belső mezőazonosítót fogad. Olyankor használja, ha egy másik alkalmazás által biztosított azonosítót kell megőrizni, amelyhez nincs előre definiált érték. Készíthet egy [FieldType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fieldtype/fieldtype/) objektumot is az azonosítóból. Az [IFieldType::get_InternalString](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifieldtype/get_internalstring/) ezt az azonosítót adja vissza vizsgálathoz.

Ez a példa egy alkalmazás‑specifikus `custom-report-id` mezőt tárolja a tartalék szöveggel `Report-042`. Nem szükséges bemeneti fájl. Az azonosító nem regisztrál számítást: az Aspose.Slides nem generál jelentés‑azonosítókat ismeretlen típushoz. Az azt megértő alkalmazásnak kell biztosítania a jelentését és frissítenie az értékét.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

A PPTX körkörös mentés után a várt típus `custom-report-id`, a várt szöveg `Report-042`. Egy `yyyy-MM-dd` karakterlánc átadása mező‑típust hozna létre, de nem állít be egyedi dátumformátumot. Rögzített dátum tetszőleges formátumban a hagyományos szöveg használatával érhető el.

## **Dátum/Idő mezők megtekintése, módosítása és eltávolítása**

Olvassa ki egy meglévő mező típusát az [IField::get_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifield/get_type/) metódussal, és változtassa meg az [IField::set_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifield/set_type/) segítségével. Ellenőrizze, hogy a mező létezik-e, mielőtt a típusához hozzáférne. Az automatikus frissítések leállításához hívja meg az [IPortion::RemoveField](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/removefield/) metódust. Ez a rész és a jelenlegi szövege megmarad, csak a mezőkapcsolatot távolítja el. Ha egy konkrét rögzített értékre van szükség, a mező eltávolítása után adja hozzá azt a szöveget.

A dátum/idő mezőkezeléshez tartozó API beállítást lásd a [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/set_currentdatetime/) metódusnál. Az alábbi példa egy explicit jóváhagyási dátumot használ, amikor egy mezőt egyszerű szöveggé alakít.

Töltse le a [sample.pptx](sample.pptx) fájlt, és helyezze a munkakönyvtárba. Két névvel ellátott szövegalakzatot tartalmaz, `UpdatedAt` és `ApprovedDate`, mindkettőnek dátum/idő mezője van, valamint egyszerű szövegcímkék. Az alábbi példa a szabályos diák felső‑szintű szövegalakzatait járja be. A dátum/idő mezőket hosszú dátumformátumra változtatja, dőltre állítja, miközben a többi formázást megőrzi. Csak az `ApprovedDate` mezői lesznek rögzített szöveggé.

A minta felismeri a beépített belső azonosítókat `datetime` és `datetime1`‑től `datetime13`‑ig. Csoportok, táblázatok, jegyzetek, elrendezések és mester‑oldalak saját szövegtárolóik bejárását igénylik, ezért nincsenek ebben a példában.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

Újra megnyitás után az `UpdatedAt` típusának `datetime3`‑nak kell lennie és dinamikus marad. Az `ApprovedDate` mezőnek hiányoznia kell, és a szövegnek `05 April 2030`‑nak kell lennie. Mindkét dátumrész dőlt, eredeti betűméretük, félkövér beállításuk és színük változatlan. Az egyszerű szövegcímkék érintetlenek maradnak. A verifikáció a két ismert alakzat első részét olvassa a mellékelt mintából.

## **Szövegformázás megőrzése**

A mező hozzáadásakor, típusának módosításakor vagy eltávolításakor dolgozzon a meglévő résszel. Ezek a műveletek megőrzik a rész formázását. Használja az [IPortion::get_PortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/get_portionformat/) metódust csak a szükséges tulajdonságok módosításához, ahogy a példák a szín vagy dőlt esetén teszik.

Kerülje el egy egész szövegkeret újjáépítését csak egy mező frissítéséhez: ez elveszítheti az eredeti részhatárokat és az egyedi formázásukat. Emellett különböztesse meg a kifejezetten beállított formázást az, amely a bekezdésből, elrendezésből vagy témából öröklődik. Lásd a [Text Formatting](/slides/hu/cpp/text-formatting/) oldalt a szélesebb formázási lehetőségekért.

## **Mezők és fejléc/lábléc helyőrzők**

Egy mező egy szövegrész része. Egy helyőrző egy prezentációs szereppel rendelkező alakzat, például lábléc vagy dia szám. Egy mező hozzáadása egy egyszerű szövegdobozhoz nem változtatja az alakzatot helyőrzővé.

A fejléc/lábléc kezelők a helyőrző szöveget és láthatóságot szabályozzák diákon, elrendezéseken és mester‑oldalakon, beleértve a függő diákra való terjesztést. Egy egyedi szövegdobozban lévő szám mező ezért akkor is hasznos lehet, ha nem használja a dia‑szám helyőrzőt. Ezzel szemben a helyőrző láthatóságának változtatása nem távolít el egy mezőt egy nem kapcsolódó szövegdobozból.

Az előre definiált fejléc‑ és lábléc típusok nem hoznak létre a megfelelő helyőrzőket, és nem biztosítják annak tartalmát. Különösen, egy szokásos PowerPoint dia nem rendelkezik fejléc‑helyőrzővel; a fejlécek a jegyzet‑oldalakhoz és a nyomtatványokhoz tartoznak. Ne feltételezze, hogy egy fejléc‑ vagy láblécmező egy tetszőleges alakzatban automatikusan megkapja a helyőrzőkezelőben beállított szöveget. Az ilyen munkafolyamatnál lásd a [Presentation Headers and Footers](/slides/hu/cpp/presentation-header-and-footer/) oldalt.

## **PPTX és PPT korlátozások**

Mentés és újra megnyitás után ellenőrizze mind a mező típusát, mind a kapott szöveget. Az azonosító megőrzése nem bizonyítja, hogy egy alkalmazás képes számítani vagy megjeleníteni az értékét.

| Format | Field behavior and limitations |
|---|---|
| PPTX | Belső mezőazonosítókat tárol a mezőszöveggel együtt. Használja a fentiekben bemutatott példákat a mentés és újra megnyitás után az előre definiált típusok és egyedi azonosítók ellenőrzéséhez. Egy ismeretlen egyedi típus nem kap automatikus számítási logikát. Egy másik alkalmazás eltérően kezelheti a nem támogatott azonosítókat. |
| PPT | Örökölt mezők reprezentációját használja, amely korlátozottabb kompatibilitással rendelkezik. A dia‑szám és az előre definiált dátum/idő mezők örökölt reprezentációval rendelkeznek. Nem támogatott egyedi mezők vagy fejlécmezők egy egyszerű dia‑szövegdobozban `*` karaktert jeleníthetnek meg. Ne támaszkodjon arra, hogy egyedi mezők vagy nem támogatott mezőkontextusok megtartják a látható szöveget. |

Hordozható, rögzített kimenethez konvertálja a nem támogatott mezőket egyszerű szöveggé, és a mentés előtt adja meg explicit módon a kívánt értéket. Ez megőrzi a kiválasztott szöveget, de szándékosan leállítja az automatikus frissítést. Tesztelje a célalkalmazást is, ha annak saját mező‑újraszámítása része a munkafolyamatnak.

## **GYIK**

**Hogyan tudom megállapítani, hogy egy megjelenített szám vagy dátum mező?**  
Ellenőrizze az [IPortion::get_Field](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/get_field/) értékét. A nem‑null visszatérés mezőt jelöl; a látható szöveg önmagában nem árul el semmit.

**Eltávolítja a mező eltávolítása a szöveget vagy a formázást?**  
Nem. A [RemoveField](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/removefield/) az adott részt egyszerű szöveggé alakítja, megőrizve a meglévő formázást. Ha egy konkrét, rögzített dátumot vagy tartalékértéket szeretne, a mező eltávolítása után állítsa be azt a szöveget.

**Definiálhat egy belső karakterlánc új dátumformátumot vagy képletet?**  
Nem. Az csak egy mező típusát azonosítja. Egy ismeretlen azonosító nem tartalmaz kiértékelőt vagy dátumformátum‑mintát. Használjon támogatott előre definiált típust, vagy formázza a kívánt értéket egyszerű szövegként.

**Miért kell a prezentációt újra ellenőrizni a mentés után?**  
A mezőazonosítók, a kiszámított szöveg és a formázás külön‑külön ellenőrzendő dolgok. A formátumkonverzió megváltoztathatja a látható eredményt, még ha a mezőazonosító megmarad is.