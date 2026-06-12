---
title: Správa tagů a vlastních dat v prezentacích pomocí PHP
linktitle: Tagy a vlastní data
type: docs
weight: 300
url: /cs/php-java/managing-tags-and-custom-data/
keywords:
- vlastnosti dokumentu
- značka
- vlastní data
- přidat značku
- párové hodnoty
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: Naučte se, jak přidávat, číst, aktualizovat a odstraňovat tagy a vlastní data v Aspose.Slides pro PHP prostřednictvím Javy, s příklady pro prezentace PowerPoint a OpenDocument.
---
## **Overview**

Tento článek vysvětluje, jak Aspose.Slides pracuje s tagy a vlastním datem v prezentacích PowerPoint. Stručně popisuje, jak jsou data uložena v souborech PPTX, uvádí, že data specifická pro prezentaci mohou existovat jako tagy a vlastní XML části, a popisuje tagy jako páry klíč‑hodnota typu string.

Ukazuje také, jak číst hodnoty tagů a jak přidávat tagy do prezentace, jednotlivého snímku nebo tvaru. Kromě toho článek pokrývá běžné úkoly správy tagů, jako je vymazání všech tagů, odebrání tagu podle názvu a získání seznamu názvů tagů.

## **Data Storage in Presentation Files**

PPTX soubory — položky s příponou .pptx — jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Formát Office Open XML definuje strukturu dat obsažených v prezentacích. 

Se *snímkem* jako jedním z prvků prezentací obsahuje *snímek část* (slide part) obsah jedné snímku. Snímek část může mít explicitní vztahy k mnoha částem — například uživatelem definovaným tagům — definovaným podle ISO/IEC 29500. 

Uživatelská data (specifická pro prezentaci) nebo uživatel mohou existovat jako tagy ([TagCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tagcollection/)) a CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}}Tagy jsou v podstatě páry klíč‑hodnota typu string.{{% /alert %}} 

## **Get Values of Tags**

V Slides odpovídá tag metodám [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getKeywords) a [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#setKeywords). Tento ukázkový kód ukazuje, jak získat hodnotu tagu pomocí Aspose.Slides for PHP via Java pro [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation):

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Add Tags to Presentations**

Aspose.Slides umožňuje přidávat tagy do prezentací. Tag typicky sestává ze dvou položek:

- název vlastní vlastnosti — `MyTag`
- hodnota vlastní vlastnosti — `My Tag Value`

Pokud potřebujete klasifikovat některé prezentace podle konkrétního pravidla nebo vlastnosti, může být užitečné přidat k těmto prezentacím tagy. Například pokud chcete seskupit všechny prezentace ze zemí Severní Ameriky, můžete vytvořit tag „North American“ a jako hodnoty přiřadit příslušné země (USA, Mexiko a Kanada).

Tento ukázkový kód ukazuje, jak přidat tag k [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) pomocí Aspose.Slides for PHP via Java:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Tagy lze také nastavit pro [Slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Nebo pro libovolný jednotlivý [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/):

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $pres->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Limitations**

Tagy přidané přes kolekci vlastních dat pomocí `getCustomData()->getTags()` jsou uloženy pouze v souboru PowerPoint. **Nejsou** přeneseny do struktury tagů PDF při exportu prezentace do PDF. Výsledkem je, že vlastní identifikátor přiřazený jako tag nelze získat z PDF se značkami.

**Workaround**: Můžete uložit vlastní identifikátor do **Alt Text** objektu (např. `$shape->setAlternativeText("MyId")`). Po exportu do PDF se Alt Text může objevit ve struktuře tagů PDF.

## **FAQ**

**Mohu odstranit všechny tagy z prezentace, snímku nebo tvaru jedním operátorem?**

Ano. [Tag collection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tagcollection/) podporuje operaci [clear](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tagcollection/clear/), která najednou smaže všechny páry klíč‑hodnota.

**Jak mohu smazat jeden tag podle jeho názvu bez procházení celé kolekce?**

Použijte operaci [remove(name)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tagcollection/remove/) na [tag collection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tagcollection/) k odstranění tagu podle jeho klíče.

**Jak mohu získat úplný seznam názvů tagů pro analýzu nebo filtrování?**

Použijte [getNamesOfTags](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tagcollection/getnamesoftags/) na [tag collection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tagcollection/); vrátí pole se všemi názvy tagů.