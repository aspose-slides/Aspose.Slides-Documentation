---
title: Správa značek a uživatelských dat v prezentacích pomocí JavaScriptu
linktitle: Značky a uživatelská data
type: docs
weight: 300
url: /cs/nodejs-java/managing-tags-and-custom-data/
keywords:
- vlastnosti dokumentu
- značka
- uživatelská data
- přidat značku
- párové hodnoty
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se přidávat, číst, aktualizovat a odstraňovat značky a uživatelská data v Aspose.Slides pro Node.js, s příklady pro prezentace PowerPoint a OpenDocument."
---
## **Přehled**

Tento článek popisuje, jak Aspose.Slides pracuje se značkami a uživatelskými daty v prezentacích PowerPoint. Stručně uvádí, jak jsou data uložena v souborech PPTX, poznamenává, že data specifická pro prezentaci mohou existovat jako značky a vlastní XML části, a popisuje značky jako dvojice klíč‑hodnota typu string.

Ukazuje také, jak číst hodnoty značek a jak přidávat značky do prezentace, jednotlivého snímku nebo tvaru. Kromě toho článek pokrývá běžné úkoly správy značek, jako je vymazání všech značek, odstranění značky podle názvu a získání seznamu názvů značek.

## **Ukládání dat v souborech prezentací**

Soubory PPTX – položky s příponou .pptx – jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Formát Office Open XML definuje strukturu dat obsažených v prezentacích.

U *snímek* je jedním z elementů v prezentaci, *část snímku* obsahuje obsah jediného snímku. Část snímku může mít explicitní vztahy k mnoha částem – například k uživatelem definovaným značkám – definovaným normou ISO/IEC 29500.

Uživatelská data (specifická pro prezentaci) nebo uživatel mohou existovat jako značky ([TagCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TagCollection)) a CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 
Značky jsou v podstatě dvojice řetězec‑klíč. 
{{% /alert %}} 

## **Získání hodnot značek**

V Slides odpovídá značka metodám [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) a [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-). Tento ukázkový kód ukazuje, jak získat hodnotu značky pomocí Aspose.Slides pro Node.js via Java pro [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation):

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přidávání značek do prezentací**

Aspose.Slides umožňuje přidávat značky do prezentací. Značka se typicky skládá ze dvou položek:

- název vlastní vlastnosti - `MyTag`  
- hodnota vlastní vlastnosti - `My Tag Value`

Pokud potřebujete klasifikovat některé prezentace podle konkrétního pravidla nebo vlastnosti, můžete z těchto důvodů značky využít. Například pokud chcete seskupit všechny prezentace z severoamerických zemí, můžete vytvořit značku *North American* a přiřadit jako hodnoty příslušné země (USA, Mexiko a Kanada).

Tento ukázkový kód ukazuje, jak přidat značku do [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) pomocí Aspose.Slides pro Node.js via Java:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Značky lze také nastavit pro [Slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Slide):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Nebo pro libovolný jednotlivý [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape):

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Omezení**

Značky přidané přes kolekci značek uživatelských dat pomocí `getCustomData().getTags()` jsou uloženy pouze v souboru PowerPoint. **Nejsou** přeneseny do struktury značek PDF při exportu prezentace do PDF. V důsledku toho nelze vlastní identifikátor přiřazený jako značka získat z označeného PDF.

**Řešení**: Můžete uložit vlastní identifikátor do **Alt Textu** objektu (např. `shape.setAlternativeText("MyId")`). Po exportu do PDF se Alt Text může objevit ve struktuře značek PDF.

## **Často kladené otázky**

**Mohu odstranit všechny značky z prezentace, snímku nebo tvaru jedním krokem?**

Ano. [kolekce značek](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tagcollection/) podporuje operaci [clear](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tagcollection/clear/), která najednou smaže všechny dvojice klíč‑hodnota.

**Jak mohu smazat jedinou značku podle jejího názvu, aniž bych procházel celou kolekci?**

Použijte operaci [remove(name)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tagcollection/remove/) na [TagCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tagcollection/) k odstranění značky podle jejího klíče.

**Jak mohu získat úplný seznam názvů značek pro analytiku nebo filtrování?**

Použijte [getNamesOfTags](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) na [kolekci značek](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/tagcollection/); vrátí pole se všemi názvy značek.