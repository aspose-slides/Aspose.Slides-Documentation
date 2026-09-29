---
title: Převést prezentace PowerPoint do XML v Javě
linktitle: PowerPoint do XML
type: docs
weight: 145
url: /cs/java/convert-powerpoint-to-xml/
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
- Java
- Aspose.Slides
description: "Převést prezentace PowerPoint a OpenDocument do souborů nebo proudu PowerPoint XML v Javě pomocí Aspose.Slides pro Java."
---
## **Přehled**

Aspose.Slides for Java může převádět prezentace PowerPoint do formátu PowerPoint XML Presentation. Výstup XML je užitečný, když potřebujete textovou reprezentaci pro inspekci struktury prezentace, odstraňování problémů generovaných dokumentů, porovnávání výstupu v automatizovaných testech nebo integraci s pracovním tokem, který spotřebovává XML místo balíčku prezentace.

Použijte metodu [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-) s hodnotou `Xml` ze třídy [SaveFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/) . Výsledek můžete zapsat přímo do souboru nebo do proudu.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` creates a PowerPoint XML Presentation. It does not extract the individual Office Open XML parts stored inside a PPTX package. If you need the exact PPTX package parts, such as `ppt/presentation.xml` or individual slide XML files, inspect the PPTX package itself.
{{% /alert %}}

## **Převést prezentaci na XML soubor**

Load a source presentation with the [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) class, and then pass the output path and `SaveFormat.Xml` to [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-). The source can be any presentation format supported for loading, such as PPT, PPTX, or ODP.

The following example converts a PPTX presentation to an XML file:

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

## **Zapsat výstup XML do proudu**

Use the stream overload of [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) when the XML must remain in memory or be passed to another component, such as a web service, storage provider, or XML processing pipeline. The following example writes the result to a [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) and obtains the resulting XML as a byte array:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Předat xmlData dalšímu komponentu v pracovním toku.
} finally {
    presentation.dispose();
}
```

## **Porovnat XML s formáty prezentace a exportu**

Zvolte výstupní formát podle toho, jak bude výsledek použit:

| Formát | Výstup | Typické použití |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML prezentace | Kontrola struktury, odstraňování problémů, porovnávání generovaného výstupu a integrace založené na XML |
| PPT (`.ppt`) | Starý binární soubor prezentace | Kompatibilita se staršími workflow PowerPointu |
| PPTX (`.pptx`) | Balíček Office Open XML obsahující více částí | Běžná editace PowerPointu a výměna prezentací |
| PDF nebo TIFF | Stránky s pevnou rozložením nebo vícestránkový obrázek | Prohlížení, tisk a archivace |
| PNG, JPEG nebo SVG | Vykreslená reprezentace jednotlivého snímku | Náhledy, ukázky a obrazové zdroje |
| HTML nebo HTML5 | Webově orientovaný výstup prezentace | Prohlížení v prohlížeči a publikování na webu |

Na rozdíl od PPT a PPTX je výstup XML určen především pro kontrolu a datově orientované pracovní toky. Na rozdíl od PDF, TIFF, HTML a formátů obrázků snímků představuje data prezentace místo vykreslování snímků jako stránek nebo vizuálních aktiv. Tabulka [supported file formats](/slides/cs/java/supported-file-formats/) uvádí všechny formáty, které Aspose.Slides může načíst, importovat, uložit nebo vykreslit.

## **Často kladené otázky**

**Je `SaveFormat.Xml` stejné jako ukládání souboru PPTX?**

Ne. PPTX je balíček obsahující více částí Office Open XML, zatímco `SaveFormat.Xml` vytvoří soubor PowerPoint XML Presentation.

**Mohu uložit výstup XML bez vytvoření souboru na disku?**

Ano. Předávejte zapisovatelný proud metodě [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Například použijte [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) pro zpracování v paměti.

**Může Aspose.Slides znovu načíst exportovaný soubor XML?**

Ano. Předávejte soubor XML nebo proud konstruktoru [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSourceFormat--) pak vrací `SourceFormat.Xml`. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) hlásí `LoadFormat.Unknown` pro tento formát, takže jej nepoužívejte k rozhodování, zda lze XML soubor otevřít.

**Převádí XML konverze každý snímek jako stránku nebo obrázek?**

Ne. XML konverze zapisuje strukturovaná data prezentace. Pro výstup orientovaný na stránky použijte PDF nebo TIFF, pro jednotlivé obrázky snímků PNG, JPEG a SVG.