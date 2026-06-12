---
title: Správa tagů a vlastních dat v prezentacích pomocí Javy
linktitle: Tagy a vlastní data
type: docs
weight: 300
url: /cs/java/managing-tags-and-custom-data/
keywords:
- vlastnosti dokumentu
- štítek
- vlastní data
- přidat štítek
- párové hodnoty
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak přidávat, číst, aktualizovat a odstraňovat tagy a vlastní data v Aspose.Slides pro Java, s příklady pro prezentace PowerPoint a OpenDocument."
---
## **Přehled**

Tento článek vysvětluje, jak Aspose.Slides pracuje s tagy a vlastními daty v prezentacích PowerPoint. Stručně popisuje, jak jsou data uložena v souborech PPTX, upozorňuje, že data specifická pro prezentaci mohou existovat jako tagy a vlastní XML části, a popisuje tagy jako páry klíč‑hodnota řetězců.

Ukazuje také, jak číst hodnoty tagů a jak přidávat tagy do prezentace, jednotlivého snímku nebo tvaru. Navíc článek pokrývá běžné úkoly správy tagů, jako je vymazání všech tagů, odstranění tagu podle názvu a získání seznamu názvů tagů.

## **Ukládání dat v souborech prezentace**

Soubory PPTX — položky s příponou .pptx — jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Formát Office Open XML definuje strukturu dat obsažených v prezentacích.  

Vzhledem k tomu, že *slide* (snímek) je jedním z prvků v prezentacích, *slide part* (část snímku) obsahuje obsah jednoho snímku. Část snímku smí mít explicitní vztahy k mnoha částem — například k uživatelem definovaným tagům — definovaným v ISO/IEC 29500.  

Vlastní data (specifická pro prezentaci) nebo uživatel mohou existovat jako tagy ([ITagCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITagCollection)) a CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ICustomXmlPartCollection)).  

{{% alert color="primary" %}}  
Tagy jsou v podstatě páry klíč‑hodnota typu řetězec.  
{{% /alert %}}  

## **Získání hodnot tagů**

V aplikaci Slides odpovídá tag metodám [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IDocumentProperties#getKeywords--) a [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Tento ukázkový kód ukazuje, jak získat hodnotu tagu pomocí Aspose.Slides for Java pro [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přidání tagů do prezentací**

Aspose.Slides vám umožňuje přidávat tagy do prezentací. Tag obvykle sestává ze dvou položek:  

- název vlastní vlastnosti – `MyTag`  
- hodnota vlastní vlastnosti – `My Tag Value`  

Pokud potřebujete klasifikovat některé prezentace podle konkrétního pravidla nebo vlastnosti, můžete mít prospěch z přidání tagů do těchto prezentací. Například pokud chcete seskupit všechny prezentace ze severoamerických zemí, můžete vytvořit tag „North American“ a přiřadit jako hodnoty příslušné země (USA, Mexiko a Kanada).  

Tento ukázkový kód ukazuje, jak přidat tag do [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) pomocí Aspose.Slides for Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Tagy lze také nastavit pro [Slide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Nebo pro libovolný jednotlivý [Shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **Omezení**

Tagy přidané prostřednictvím kolekce vlastních dat tagů pomocí `getCustomData().getTags()` jsou uloženy pouze v souboru PowerPoint. **Nejsou** přenášeny do struktury tagů PDF při exportu prezentace do PDF. V důsledku toho nelze vlastní identifikátor přiřazený jako tag získat z označeného PDF.  

**Obcházení**: Můžete uložit vlastní identifikátor do **Alt Text** objektu (např. `shape.setAlternativeText("MyId")`). Po exportu do PDF se Alt Text může objevit ve struktuře tagů PDF.  

## **Často kladené otázky**

**Mohu odstranit všechny tagy z prezentace, snímku nebo tvaru jedním operací?**  

Ano. [Kolekce tagů](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tagcollection/) podporuje operaci [clear](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tagcollection/#clear--) , která najednou odstraní všechny páry klíč‑hodnota.  

**Jak mohu smazat jeden tag podle jeho názvu bez iterace celou kolekcí?**  

Použijte operaci [Remove(name)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) na [kolekci tagů](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tagcollection/), abyste odstranili tag podle jeho klíče.  

**Jak mohu získat kompletní seznam názvů tagů pro analytiku nebo filtrování?**  

Použijte [getNamesOfTags](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tagcollection/#getNamesOfTags--) na [kolekci tagů](https://reference.aspose.com/slides/cs/java/com.aspose.slides/tagcollection/); vrátí pole všech názvů tagů.