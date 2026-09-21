---
title: Správa textových polí v prezentacích PowerPoint v Javě
linktitle: Textová pole
type: docs
weight: 52
url: /cs/java/text-fields/
keywords:
- textové pole
- automatický text
- číslo snímku
- datum a čas
- záhlaví
- zápatí
- textová část
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Vytvářejte, kontrolujte, upravujte a odstraňujte textová pole v prezentacích PowerPoint pomocí Aspose.Slides pro Javu. Zachovávejte formátování a ověřujte uložené soubory PPTX a PPT."
---
## **Přehled**

Textový odstavec se skládá z částí. Běžná [IPortion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/) obsahuje doslovný text; část pole také obsahuje [IField](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifield/), jejíž typ určuje automaticky aktualizovanou hodnotu, například číslo snímku nebo datum. Dvě části mohou zobrazovat stejné znaky, zatímco jen jedna obsahuje pole.

Použijte [IPortion.getField](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/#getField--) k jejich rozlišení: pro obyčejný text je `null`. [IPortion.addField](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) převádí existující část na pole. Udržujte popisek a jeho dynamickou hodnotu v samostatných částech, aby převod hodnoty také nenahradil popisek.

Tento průvodce popisuje pole v textech, jejich formátování a ukládání do PPTX a PPT. Pro textová pole a odstavce viz [Manage Text](/slides/cs/java/manage-text/).

## **Vytvoření pole čísla snímku**

Následující úplný příklad vytvoří textové pole obsahující doslovný popisek `Slide ` následovaný automaticky aktualizovaným číslem. Před přidáním pole nastaví velikost, tloušťku a barvu čísla, poté znovu otevře uloženou prezentaci a zkontroluje typ pole, text a formátování. Vstupní soubor není vyžadován.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

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

Nová prezentace začíná číslem snímku 1, takže text je `Slide 1` a oba testy vypíšou `true`. Číslo zůstane polem po opětovném otevření; není to doslovné `1`. Přehozy a indexy v ověření odkazují na tvar a části vytvořené tímto příkladem.

## **Výběr typu pole**

[FieldType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fieldtype/) implementuje [IFieldType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifieldtype/) a poskytuje následující metody pro získání předdefinovaných hodnot. Předávejte odpovídající hodnotu metodě [addField](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Metoda | Účel |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fieldtype/#getSlideNumber--) | Aktuální číslo snímku. |
| [getDateTime](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fieldtype/#getDateTime--) | Datum/čas ve výchozím formátu aplikace vykreslující prezentaci. |
| [getDateTime1](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fieldtype/#getDateTime9--) | Předdefinované formáty data nebo kombinované formáty data/času. |
| [getDateTime10](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fieldtype/#getDateTime13--) | Předdefinované formáty času, s možností sekund a 12‑hodinového formátu. |
| [getHeader](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fieldtype/#getHeader--) | Pole záhlaví; viz omezení zástupných symbolů a formátu níže. |
| [getFooter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fieldtype/#getFooter--) | Pole zápatí. |

Například [getDateTime3](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fieldtype/#getDateTime3--) představuje den, úplný název měsíce a rok v angličtině. Jedná se o předdefinované formáty pole, nikoli o libovolné řetězce formátu data v Javě. Jazyk nastavený pomocí [setLanguageId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) a aplikace zpracovávající prezentaci mohou ovlivnit zobrazovaný výsledek.

## **Vytvoření pole z interního řetězce**

Přetížení metody [addField](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/#addField-java.lang.String-) přijímá interní identifikátor pole. Použijte ho při zachování identifikátoru poskytnutého jinou aplikací, která nemá předdefinovanou hodnotu. Můžete také vytvořit [FieldType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) z tohoto identifikátoru. [IFieldType.getInternalString](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifieldtype/#getInternalString--) odhalí tento identifikátor pro kontrolu.

Tento příklad ukládá aplikačně specifické pole `custom-report-id` s náhradním textem `Report-042`. Identifikátor neregistruje žádný výpočet: Aspose.Slides nevytváří ID zpráv pro neznámý typ. Aplikace, která tento identifikátor rozumí, musí poskytnout jeho význam a aktualizovat jeho hodnotu.

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

Po tomto kole PPTX je typ `custom-report-id` a text je `Report-042`. Předání řetězce jako `yyyy-MM-dd` by pojmenovalo typ pole; nenastaví vlastní formát data. Pro pevné datum v libovolném formátu použijte obyčejný text.

## **Prohlížení, úprava a odebrání polí datum/čas**

Změňte existující pole pomocí [IField.setType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Ověřte, že pole existuje, než získáte jeho typ. Pro zastavení automatických aktualizací zavolejte [IPortion.removeField](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/#removeField--). Tím zachováte část a její aktuální text a zároveň odeberete spojení s polem. Pokud potřebujete konkrétní pevnou hodnotu, přiřaďte tento text po odebrání pole.

Pro nastavení API souvisejícího se zpracováním pole datum/čas viz [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Níže uvedený příklad používá explicitní datum schválení při převodu pole na obyčejný text.

Stáhněte [sample.pptx](sample.pptx) a umístěte jej do pracovního adresáře. Obsahuje dva pojmenované textové tvary, `UpdatedAt` a `ApprovedDate`, každý s polem datum/čas, a také obyčejné textové popisky. Následující příklad prochází textové tvary na hlavní úrovni na běžných snímcích. Převádí pole datum/čas na dlouhý formát data a nastavuje je kurzívou, přičemž zachovává jejich další formátování. Pouze pole v `ApprovedDate` se promění na pevný text.

Ukázka rozpoznává vestavěné interní identifikátory `datetime` a `datetime1` až po `datetime13`. Skupiny, tabulky, poznámky, rozvržení a předlohy vyžadují procházení jejich vlastních textových kontejnerů a spadají mimo rozsah tohoto příkladu.

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

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
                        String fixedDate = approvalDate.format(dateFormat);
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

Po opětovném otevření má `UpdatedAt` typ `datetime3` a zůstává dynamické. `ApprovedDate` nemá pole a obsahuje `05 April 2030`. Obě datové části jsou kurzívou a jejich původní velikost písma, tučnost a barva zůstávají zachovány. Obyčejné textové popisky jsou nezměněny. Ověřování čte první část dvou známých tvarů ve dodaném vzorku.

## **Zachování formátování textu**

Při přidávání pole, změně jeho typu nebo odebrání pracujte s existující částí. Tyto operace zachovávají formátování této části. Použijte [IPortion.getPortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/#getPortionFormat--) k tomu, abyste změnili jen požadované vlastnosti, jak ukazují příklady pro barvu nebo kurzívu.

Vyhněte se přestavování celého textového rámce jen kvůli aktualizaci jednoho pole: může to způsobit ztrátu původních hranic částí a jejich individuálního formátování. Rozlišujte také výslovně nastavené formátování od formátování zděděného z odstavce, rozvržení nebo motivu. Viz [Text Formatting](/slides/cs/java/text-formatting/) pro širší možnosti formátování.

## **Pole a zástupné symboly záhlaví/zápatí**

Pole je součástí textové části. Zástupný symbol je tvar s rolí v prezentaci, například zápatí nebo číslo snímku. Přidání pole do obyčejného textového pole nepromění tento tvar na zástupný symbol.

Správci záhlaví/zápatí řídí text a viditelnost zástupných symbolů na snímcích, rozvrženích a předlohách, včetně propagace na závislé snímky. Pole čísla v uživatelském textovém poli tak může být užitečné i když nepoužíváte zástupný symbol čísla snímku. Naopak změna viditelnosti zástupného symbolu neodstraní pole z nesouvisejícího textového pole.

Předdefinované typy záhlaví a zápatí nevytvářejí odpovídající zástupné symboly ani nezasílají jejich obsah. Konkrétně běžný snímek PowerPointu nemá zástupný symbol záhlaví; záhlaví patří k poznámkovým stránkám a podkladům. Nepředpokládejte, že pole záhlaví nebo zápatí v libovolném tvaru automaticky získá text nastavený pomocí správce zástupných symbolů. Pro takový postup viz [Presentation Headers and Footers](/slides/cs/java/presentation-header-and-footer/).

## **Omezení PPTX a PPT**

Zkontrolujte jak typ pole, tak jeho výsledný text po uložení a opětovném otevření. Zachování identifikátoru neprokazuje, že aplikace dokáže vypočítat nebo zobrazit jeho hodnotu.

| Formát | Chování pole a omezení |
|---|---|
| PPTX | Ukládá interní identifikátory polí spolu s textem pole. V kontrolách během kola přečtení přežily předdefinované typy a výše použité vlastní identifikátory uložení i opětovné otevření. Neznámý vlastní typ zachoval svůj náhradní text; nezískal automatickou výpočetní logiku. Jiná aplikace může s nepodporovanými identifikátory zacházet odlišně. |
| PPT | Používá zastaralé reprezentace polí a má omezenější kompatibilitu. V kontrolách během kola přečtení přežily pole čísla snímku a předdefinovaná pole datum/čas. Vlastní pole v obyčejném textovém poli snímku se po opětovném otevření zobrazilo s identifikátorem, ale s textem `*`; pole záhlaví ve stejném kontextu také produkovalo `*`. Nespoléhejte se na to, že vlastní pole nebo nepodporované kontexty polí zachovají svůj viditelný text. |

Pro přenosný, pevný výstup převádějte nepodporovaná pole na obyčejný text a před uložením explicitně přiřaďte požadovanou hodnotu. Tím se zachová zvolený text, ale úmyslně se zastaví automatické aktualizace. Otestujte také cílovou aplikaci, pokud je její vlastní přepočet polí součástí vašeho pracovního postupu.

## **Často kladené otázky**

**Jak zjistit, zda zobrazené číslo nebo datum je pole?**  
Prohlédněte [IPortion.getField](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/#getField--). Ne‑null hodnota identifikuje pole; samotný zobrazený text to nezjistí.

**Odstraní odstranění pole jeho text nebo formátování?**  
Ne. [removeField](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/#removeField--) převádí existující část na obyčejný text. Pokud potřebujete konkrétní zamražené datum nebo náhradní hodnotu, přiřaďte ji po odstranění pole.

**Může interní řetězec definovat nový formát data nebo vzorec?**  
Ne. Identifikuje typ pole. Neznámý identifikátor neposkytuje vyhodnocovač ani vzorový řetězec formátu data v Javě. Použijte podporovaný předdefinovaný typ nebo formátujte hodnotu sami jako obyčejný text.

**Proč po uložení znovu kontrolovat prezentaci?**  
Identifikátory polí, vypočtený text a formátování jsou oddělené věci, které je třeba ověřit. Konverze formátu může změnit viditelný výsledek i když identifikátor pole zůstane přítomen.