---
title: Správa štítků a vlastních dat v prezentacích na Androidu
linktitle: Štítky a vlastní data
type: docs
weight: 300
url: /cs/androidjava/managing-tags-and-custom-data
keywords:
- vlastnosti dokumentu
- štítek
- vlastní data
- přidat štítek
- párové hodnoty
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Přidávejte, čtěte, aktualizujte a odstraňujte štítky a vlastní data v Aspose.Slides pro Android, s příklady v jazyce Java pro prezentace PowerPoint a OpenDocument."
---
## **Přehled**

Tento článek vysvětluje, jak Aspose.Slides pracuje se štítky a vlastními daty v prezentacích PowerPoint. Stručně popisuje, jak jsou data uložena v souborech PPTX, uvádí, že data specifická pro prezentaci mohou existovat jako štítky a vlastní XML části, a popisuje štítky jako páry řetězcových klíč‑hodnota.

Ukazuje také, jak číst hodnoty štítků a jak přidávat štítky do prezentace, konkrétní snímku nebo tvaru. Navíc článek pokrývá běžné úlohy správy štítků, jako je vymazání všech štítků, odstranění štítku podle názvu a získání seznamu názvů štítků.

## **Ukládání dat v souborech prezentace**

Soubory PPTX — položky s příponou .pptx — jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Formát Office Open XML definuje strukturu pro data obsažená v prezentacích.

S *snímkem* jako jedním z elementů prezentace obsahuje *část snímku* (slide part) obsah jednoho snímku. Část snímku může mít explicitní vztahy k mnoha částem — například k uživatelem definovaným štítkům — definovaným normou ISO/IEC 29500.

Vlastní data (specifická pro prezentaci) nebo uživatel mohou existovat jako štítky ([ITagCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITagCollection)) a CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 
Štítky jsou v podstatě páry klíč‑hodnota typu řetězec. 
{{% /alert %}} 

## **Získání hodnot štítků**

V slides odpovídá štítek metodám [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) a [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-). Tento ukázkový kód vám ukáže, jak získat hodnotu štítku pomocí Aspose.Slides pro Android via Java pro [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přidání štítků do prezentací**

Aspose.Slides vám umožňuje přidávat štítky do prezentací. Štítek obvykle sestává ze dvou položek:

- název vlastnosti — `MyTag`
- hodnota vlastnosti — `My Tag Value`

Pokud potřebujete klasifikovat některé prezentace podle konkrétního pravidla nebo vlastnosti, může vám přidání štítků do těchto prezentací pomoci. Například pokud chcete seskupit všechny prezentace z severoamerických zemí, můžete vytvořit štítek „North American“ a přiřadit jako hodnoty příslušné země (USA, Mexiko a Kanada).

Tento ukázkový kód ukazuje, jak přidat štítek do [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) pomocí Aspose.Slides pro Android via Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Štítky lze také nastavit pro [Slide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Nebo pro libovolný jednotlivý [Shape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IAutoShape):

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

Štítky přidané přes kolekci vlastních dat pomocí `getCustomData().getTags()` jsou uloženy pouze v souboru PowerPoint. **Nejsou** přeneseny do struktury štítků PDF při exportu prezentace do PDF. V důsledku toho nelze vlastní identifikátor přiřazený jako štítek získat z označeného PDF.

**Obejití**: Můžete uložit vlastní identifikátor do **Alt Text** objektu (např. `shape.setAlternativeText("MyId")`). Po exportu do PDF se může Alt Text objevit ve struktuře štítků PDF.

## **Často kladené otázky**

**Mohu odstranit všechny štítky z prezentace, snímku nebo tvaru najednou?**

Ano. [Kolekce štítků](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/) podporuje operaci [clear](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/#clear--) , která najednou smaže všechny páry klíč‑hodnota.

**Jak mohu smazat jeden štítek podle jeho názvu, aniž bych procházel celou kolekci?**

Použijte operaci [remove(name)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) na [kolekci štítků](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/) k odstranění štítku podle jeho klíče.

**Jak mohu získat úplný seznam názvů štítků pro analýzu nebo filtrování?**

Použijte [getNamesOfTags](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) na [kolekci štítků](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/tagcollection/); vrátí pole všech názvů štítků.