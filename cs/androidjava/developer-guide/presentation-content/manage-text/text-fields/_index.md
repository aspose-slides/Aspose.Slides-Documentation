---
title: Správa textových polí v prezentacích PowerPoint na Androidu
linktitle: Textová pole
type: docs
weight: 52
url: /cs/androidjava/text-fields/
keywords:
- textové pole
- automatický text
- číslo snímku
- datum a čas
- záhlaví
- zápatí
- textový úsek
- PowerPoint
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Vytvářejte, kontrolujte, upravujte a odstraňujte textová pole v prezentacích PowerPoint pomocí Aspose.Slides pro Android v jazyce Java. Zachovejte formátování a ověřte uložené soubory PPTX a PPT."
---
## **Overview**

Textový odstavec se skládá z úseků. Běžný [IPortion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportion/) obsahuje doslovný text; úsek pole má také [IField](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifield/) jejímž typem je automaticky aktualizovaná hodnota, například číslo snímku nebo datum. Dva úseky mohou zobrazovat stejné znaky, ale jen jeden obsahuje pole.

Použijte [IPortion.getField](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportion/#getField--) pro jejich rozlišení: pro běžný text je `null`. [IPortion.addField](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) převede existující úsek na pole. Uchovávejte popisek a jeho dynamickou hodnotu v samostatných úsecích, aby převod hodnoty také nenahradil popisek.

Tato příručka pokrývá pole uvnitř textu, jejich formátování a ukládání do formátů PPTX a PPT. Pro textové rámečky a odstavce viz [Správa textu](/slides/cs/androidjava/manage-text/).

## **Create a Slide Number Field**

Následující kompletní příklad vytvoří textové pole obsahující doslovný popisek `Slide ` následovaný automaticky aktualizovaným číslem. Před přidáním pole nastaví velikost, tučnost a barvu čísla, poté znovu otevře uloženou prezentaci a zkontroluje typ pole, text a formátování. Vstupní soubor není vyžadován.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Nová prezentace začíná číslem snímku 1, takže text je `Slide 1` a oba ověření vytisknou `true`. Číslo zůstává polem po opětovném otevření; není to doslovné `1`. Přetypování a indexy v ověření odkazují na tvar a úseky vytvořené tímto příkladem.

## **Choose a Field Type**

[FieldType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fieldtype/) implementuje [IFieldType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifieldtype/) a poskytuje následující metody pro získání předdefinovaných hodnot. Předávejte vhodnou hodnotu metodě [addField](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Metoda | Účel |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | Aktuální číslo snímku. |
| [getDateTime](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | Datum/čas ve výchozím formátu aplikace. |
| [getDateTime1](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | Předdefinované formáty data nebo kombinované formáty data/času. |
| [getDateTime10](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | Předdefinované formáty času, s možnostmi sekund a 12‑hodinového formátu. |
| [getHeader](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fieldtype/#getHeader--) | Pole záhlaví; viz omezení zástupných znaků a formátu níže. |
| [getFooter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fieldtype/#getFooter--) | Pole zápatí. |

Například [getDateTime3](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) představuje den, úplný název měsíce a rok v angličtině. Jedná se o předdefinované formáty pole, nikoli o libovolné řetězce formátu data v Javě. Jazyk nastavený pomocí [setLanguageId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) a aplikace zpracovávající prezentaci mohou ovlivnit zobrazený výsledek.

## **Create a Field from an Internal String**

Přetížená metoda řetězce [addField](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) přijímá interní identifikátor pole. Použijte ji, když chcete zachovat identifikátor poskytnutý jinou aplikací, která nemá předdefinovanou hodnotu. Můžete také vytvořit [FieldType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) z tohoto identifikátoru. [IFieldType.getInternalString](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) tento identifikátor zpřístupní k prohlédnutí.

Tento příklad ukládá aplikací specifické pole `custom-report-id` s náhradním textem `Report-042`. Identifikátor nezaregistruje výpočet: Aspose.Slides negeneruje reportová ID pro neznámý typ. Aplikace, která tento identifikátor rozumí, musí poskytnout jeho význam a aktualizovat jeho hodnotu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Po tomto PPTX průchodu je typ `custom-report-id` a text je `Report-042`. Předání řetězce jako `yyyy-MM-dd` by pojmenovalo typ pole; nenastaví to vlastní formát data. Pro pevné datum v libovolném formátu použijte běžný text.

## **Inspect, Modify, and Remove Date/Time Fields**

Změňte existující pole pomocí [IField.setType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Ověřte, že pole existuje, než získáte jeho typ. Pro zastavení automatických aktualizací zavolejte [IPortion.removeField](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportion/#removeField--). Tím se úsek zachová spolu se současným textem, zatímco se odstraní asociace s polem. Pokud potřebujete konkrétní pevnou hodnotu, přiřaďte tento text po odstranění pole.

Pro nastavení API souvisejícího se zpracováním datum/čas polí viz [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Níže uvedený příklad používá explicitní datum schválení při převodu pole na běžný text.

Stáhněte [sample.pptx](sample.pptx) a umístěte jej do pracovního adresáře. Obsahuje dva pojmenované textové tvary `UpdatedAt` a `ApprovedDate`, každý s datumovým/časovým polem, plus běžné textové popisky. Následující příklad prochází textové tvary nejvyšší úrovně na normálních snímcích. Převádí datumové/časové pole na formát dlouhého data a kurzívou, přičemž zachovává jejich další formátování. Pouze pole v `ApprovedDate` se stane pevným textem.

Ukázka rozpoznává vestavěné interní identifikátory `datetime` a `datetime1` až po `datetime13`. Skupiny, tabulky, poznámky, rozvržení a hlavní šablony vyžadují procházení jejich vlastních textových kontejnerů a nejsou součástí tohoto příkladu.

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Po opětovném otevření má `UpdatedAt` typ `datetime3` a zůstává dynamický. `ApprovedDate` nemá pole a obsahuje `05 April 2030`. Oba datumové úseky jsou kurzívou a jejich původní velikost písma, nastavení tučnosti a barva zůstávají zachovány. Běžné textové popisky zůstávají beze změny. Ověření čte první úsek ze dvou známých tvarů v dodaném vzorku.

## **Preserve Text Formatting**

Pracujte s existujícím úsekem při přidávání pole, změně jeho typu nebo jeho odstraňování. Tyto operace zachovají formátování úseku. Použijte [IPortion.getPortionFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportion/#getPortionFormat--) pro změnu jen požadovaných vlastností, jak ukazují příklady pro barvu nebo kurzívu.

Vyhněte se přestavbě celého textového rámce jen kvůli aktualizaci jednoho pole: může to ztratit původní hranice úseků a jejich individuální formátování. Rozlišujte také explicitně nastavené formátování od formátování zděděného od odstavce, rozvržení nebo motivu. Viz [Formátování textu](/slides/cs/androidjava/text-formatting/) pro širší možnosti formátování.

## **Fields and Header/Footer Placeholders**

Pole je součástí textového úseku. Zástupný znak (placeholder) je tvar s rolí v prezentaci, například zápatí nebo číslo snímku. Přidání pole do běžného textového pole nepromění tento tvar na zástupný znak.

Správci záhlaví/zápatí řídí text zástupných znaků a jejich viditelnost na snímcích, rozvrženích a hlavních šablonách, včetně šíření na podřízené snímky. Pole s číslem v uživatelském textovém poli může být užitečné i tehdy, když nepoužíváte zástupný znak čísla snímku. Naopak změna viditelnosti zástupného znaku neodstraní pole z nesouvisejícího textového pole.

Předdefinované typy záhlaví a zápatí nevytvářejí odpovídající zástupné znaky ani neposkytují jejich obsah. Konkrétně běžný PowerPointový snímek nemá zástupný znak záhlaví; záhlaví patří ke stránkám poznámek a podkladům. Nepředpokládejte, že pole záhlaví nebo zápatí v libovolném tvaru automaticky získá text nastavený přes správce zástupných znaků. Pro tento postup viz [Záhlaví a zápatí prezentace](/slides/cs/androidjava/presentation-header-and-footer/).

## **PPTX and PPT Limitations**

Zkontrolujte jak typ pole, tak jeho výsledný text po uložení a opětovném otevření. Zachování identifikátoru neprokazuje, že aplikace dokáže vypočítat nebo zobrazit jeho hodnotu.

| Formát | Chování pole a omezení |
|---|---|
| PPTX | Ukládá interní identifikátory pole společně s textem pole. V kontrolách po průchodu se předdefinované typy a vlastní identifikátor použité výše přežily uložení a otevření. Neznámý vlastní typ si zachoval náhradní text; nezískal automatickou logiku výpočtu. Jiná aplikace může s nepodporovanými identifikátory zacházet odlišně. |
| PPT | Používá starší reprezentace pole a má omezenější kompatibilitu. V kontrolách po průchodu přežily pole čísla snímku a předdefinovaná datum/čas pole. Vlastní pole v běžném textovém poli snímku se po otevření objeví s identifikátorem, ale jeho text bude `*`; stejné se stane i s polem záhlaví v tomto kontextu. Nespoléhejte se na to, že vlastní pole nebo nepodporované kontexty pole zachovají jejich viditelný text. |

Pro přenosný, pevný výstup převádějte nepodporovaná pole na běžný text a před uložením explicitně přiřaďte požadovanou hodnotu. Tím zachováte zvolený text, ale úmyslně zastavíte automatické aktualizace. Otestujte také cílovou aplikaci, pokud je její vlastní přepočet polí součástí vašeho pracovního postupu.

## **FAQ**

**Jak mohu zjistit, zda je zobrazené číslo nebo datum pole?**

Prohlédněte si [IPortion.getField](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportion/#getField--). Nenulová hodnota identifikuje pole; samotný zobrazovaný text to nelze určit.

**Odstraní odstranění pole jeho text nebo formátování?**

Ne. [removeField](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportion/#removeField--) převádí existující úsek na běžný text. Pokud potřebujete konkrétní zamrzlý datum nebo náhradní hodnotu, přiřaďte tento text po odstranění pole.

**Může interní řetězec definovat nový formát data nebo vzorec?**

Ne. Identifikuje typ pole. Neznámý identifikátor neposkytuje vyhodnocovač ani vzorový řetězec formátu data v Javě. Použijte podporovaný předdefinovaný typ nebo formátujte hodnotu sami jako běžný text.

**Proč znovu kontrolovat prezentaci po jejím uložení?**

Identifikátory pole, vypočítaný text a formátování jsou oddělené věci, které je třeba ověřit. Konverze formátu může změnit viditelný výsledek, i když identifikátor pole zůstane přítomen.