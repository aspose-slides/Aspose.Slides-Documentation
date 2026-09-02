---
title: Převod prezentací PowerPoint do XML na Androidu
linktitle: PowerPoint do XML
type: docs
weight: 145
url: /cs/androidjava/convert-powerpoint-to-xml/
keywords:
- převést PowerPoint do XML
- převést prezentaci do XML
- PPT do XML
- PPTX do XML
- ODP do XML
- PowerPoint XML prezentace
- SaveFormat.Xml
- uložit prezentaci jako XML
- exportovat prezentaci do XML
- XML proud
- Android
- Java
- Aspose.Slides
description: "Převod prezentací PowerPoint a OpenDocument do souborů nebo proudů PowerPoint XML na Androidu s Aspose.Slides."
---
## **Přehled**

Aspose.Slides pro Android prostřednictvím Java dokáže převést prezentace PowerPoint do formátu PowerPoint XML Presentation. Výstup XML je užitečný, když potřebujete textovou reprezentaci pro kontrolu struktury prezentace, ladění generovaných dokumentů, porovnávání výstupu v automatizovaných testech nebo integraci s pracovním postupem, který používá XML místo balíčku prezentace.

Použijte metodu [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) s [SaveFormat.Xml](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/#Xml). Výsledek můžete zapsat přímo do souboru nebo do proudu.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` vytváří PowerPoint XML Presentation. Neextrahuje jednotlivé části Office Open XML uložené uvnitř balíčku PPTX. Pokud potřebujete přesné části balíčku PPTX, jako je `ppt/presentation.xml` nebo jednotlivé XML soubory snímků, prohlédněte si samotný balíček PPTX.
{{% /alert %}}

## **Převod prezentace do XML souboru**

Načtěte zdrojovou prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) a poté předávejte cestu k výstupu a [SaveFormat.Xml](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/saveformat/#Xml) metodě [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). Zdroj může být libovolný formát prezentace podporovaný pro načítání, například PPT, PPTX nebo ODP.

Následující příklad převádí PPTX prezentaci do XML souboru:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Zápis výstupu XML do proudu**

Použijte přetížení proudu metody [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) , když XML musí zůstat v paměti nebo být předáno dalšímu komponentu, například webové službě, poskytovateli úložiště nebo pipeline zpracování XML. Následující příklad zapisuje výsledek do [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) a získává generované XML jako pole bajtů:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // Předat xmlData dalšímu komponentu v pracovním postupu.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Porovnání XML s formáty prezentací a exportu**

Zvolte výstupní formát podle toho, jak bude výsledek použit:

| Formát | Výstup | Typické použití |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Kontrola struktury, ladění, porovnávání generovaného výstupu a integrace založené na XML |
| PPT (`.ppt`) | Legacy binární soubor prezentace | Kompatibilita se staršími pracovními postupy PowerPoint |
| PPTX (`.pptx`) | Office Open XML balíček obsahující více částí | Běžná úprava PowerPoint a výměna prezentací |
| PDF nebo TIFF | Stránky s pevnou rozložením nebo vícestránkový obrázek | Prohlížení, tisk a archivace |
| PNG, JPEG nebo SVG | Vykreslená reprezentace jednotlivého snímku | Náhledy, ukázky a obrazová aktiva |
| HTML nebo HTML5 | Webově orientovaný výstup prezentace | Prohlížení v prohlížeči a publikování na webu |

Na rozdíl od PPT a PPTX je výstup XML primárně určen pro kontrolu a datově orientované pracovní postupy. Na rozdíl od PDF, TIFF, HTML a formátů obrázků snímků představuje data prezentace spíše než vykreslené snímky jako stránky nebo vizuální aktiva. Tabulka [supported file formats](/slides/cs/androidjava/supported-file-formats/) uvádí PowerPoint XML Presentation jako formát pouze pro ukládání, takže jej nepoužívejte, pokud pracovní postup musí načíst exportovaný soubor zpět do Aspose.Slides pro další úpravy.

## **Často kladené otázky**

**Je `SaveFormat.Xml` stejné jako ukládání souboru PPTX?**

Ne. PPTX je balíček obsahující více částí Office Open XML, zatímco `SaveFormat.Xml` vytváří soubor PowerPoint XML Presentation.

**Mohu uložit výstup XML bez vytvoření souboru na disku?**

Ano. Předávejte zapisovatelný proud metodě [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Například použijte [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) pro zpracování v paměti.

**Může Aspose.Slides znovu načíst exportovaný XML soubor?**

Ne. PowerPoint XML Presentation je v současnosti podporováno jen pro ukládání, ne pro načítání. Pro obousměrnou úpravu použijte PPTX nebo jiný podporovaný formát prezentace.

**Převádí XML konverze každý snímek jako stránku nebo obrázek?**

Ne. XML konverze zapisuje strukturovaná data prezentace. Pro výstup orientovaný na stránky použijte PDF nebo TIFF, pro jednotlivé obrázky snímků PNG, JPEG nebo SVG.