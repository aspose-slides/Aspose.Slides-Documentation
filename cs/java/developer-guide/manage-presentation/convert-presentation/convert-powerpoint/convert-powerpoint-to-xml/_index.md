---
title: Převod prezentací PowerPoint do XML v Javě
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
description: "Převádějte prezentace PowerPoint a OpenDocument na soubory nebo proudy PowerPoint XML v Javě s Aspose.Slides pro Java."
---
## **Přehled**

Aspose.Slides pro Java může převádět prezentace PowerPoint do formátu PowerPoint XML Presentation. Výstup XML je užitečný, když potřebujete textovou reprezentaci pro kontrolu struktury prezentace, odlaďování vygenerovaných dokumentů, porovnávání výstupů v automatizovaných testech nebo integraci s pracovním postupem, který konzumuje XML místo balíčku prezentace.

Použijte metodu [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-) s hodnotou `Xml` ze třídy [SaveFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/saveformat/) . Můžete výsledek zapsat přímo do souboru nebo do proudu.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` vytváří prezentaci PowerPoint XML. Neextrahuje jednotlivé části Office Open XML uložené uvnitř balíčku PPTX. Pokud potřebujete přesné části balíčku PPTX, například `ppt/presentation.xml` nebo jednotlivé XML soubory snímků, zkontrolujte samotný balíček PPTX.
{{% /alert %}}

## **Převod prezentace do XML souboru**

Načtěte zdrojovou prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a poté předávejte výstupní cestu a `SaveFormat.Xml` metodě [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Zdroj může být libovolný formát prezentace podporovaný pro načítání, jako PPT, PPTX nebo ODP.

Následující příklad převádí prezentaci PPTX do XML souboru:

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

## **Zápis XML výstupu do proudu**

Použijte přetížení proudu metody [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) , když musí XML zůstat v paměti nebo být předáno jinému komponentu, například webové službě, poskytovateli úložiště nebo zpracovatelskému řetězci XML. Následující příklad zapíše výsledek do [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) a získá výsledné XML jako pole bajtů:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Předat xmlData dalšímu komponentu v pracovním postupu.
} finally {
    presentation.dispose();
}
```

## **Porovnání XML s formáty prezentací a exportu**

Vyberte výstupní formát podle toho, jak bude výsledek použit:

| Formát | Výstup | Typické použití |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Prezentace PowerPoint XML | Kontrola struktury, odlaďování, porovnávání vygenerovaného výstupu a integrace založená na XML |
| PPT (`.ppt`) | Starý binární soubor prezentace | Kompatibilita se staršími pracovními postupy PowerPoint |
| PPTX (`.pptx`) | Balíček Office Open XML obsahující více částí | Běžné editování PowerPoint a výměna prezentací |
| PDF nebo TIFF | Stránky s pevnou rozvržením nebo více‑stránkový obrázek | Prohlížení, tisk a archivace |
| PNG, JPEG nebo SVG | Vykreslená reprezentace jednotlivého snímku | Náhledy, ukázky a obrazové zdroje |
| HTML nebo HTML5 | Webově orientovaný výstup prezentace | Prohlížení v prohlížeči a publikování na webu |

Na rozdíl od PPT a PPTX je výstup XML primárně určen pro kontrolu a datově orientované pracovní postupy. Na rozdíl od PDF, TIFF, HTML a formátů obrázků snímků představuje data prezentace místo vykreslování snímků jako stránek nebo vizuálních zdrojů. Tabulka [supported file formats](/slides/cs/java/supported-file-formats/) uvádí PowerPoint XML Presentation jako formát pouze pro ukládání, takže jej nepoužívejte, pokud pracovní postup musí načíst exportovaný soubor zpět do Aspose.Slides pro další úpravy.

## **Často kladené otázky**

**Je `SaveFormat.Xml` stejné jako ukládání souboru PPTX?**

Ne. PPTX je balíček obsahující více částí Office Open XML, zatímco `SaveFormat.Xml` vytváří soubor PowerPoint XML Presentation.

**Mohu uložit XML výstup bez vytvoření souboru na disku?**

Ano. Předávejte zapisovatelný proud metodě [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Například použijte [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) pro zpracování v paměti.

**Dokáže Aspose.Slides znovu načíst exportovaný XML soubor?**

Ne. PowerPoint XML Presentation je aktuálně podporována pouze pro ukládání, ne pro načítání. Použijte PPTX nebo jiný podporovaný formát prezentace, pokud je potřeba obousměrná úprava.

**Převádí XML konverze každý snímek jako stránku nebo obrázek?**

Ne. XML konverze zapisuje strukturovaná data prezentace. Pro výstup orientovaný na stránky použijte PDF nebo TIFF, pro jednotlivé obrázky snímků PNG, JPEG a SVG.