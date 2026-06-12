---
title: Správa tagů a vlastních dat v prezentacích pomocí Pythonu
linktitle: Tagy a vlastní data
type: docs
weight: 300
url: /cs/python-net/managing-tags-and-custom-data/
keywords:
- vlastnosti dokumentu
- značka
- vlastní data
- přidat značku
- párové hodnoty
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak přidávat, číst, aktualizovat a odstraňovat tagy a vlastní data v Aspose.Slides pro Python via .NET, s příklady pro prezentace PowerPoint a OpenDocument."
---
## **Přehled**

Tento článek vysvětluje, jak Aspose.Slides pracuje s tagy a vlastními daty v prezentacích PowerPoint. Stručně popisuje, jak jsou data uložena v souborech PPTX, upozorňuje, že data specifická pro prezentaci mohou existovat jako tagy a vlastní XML části, a popisuje tagy jako páry klíč‑hodnota řetězců.

Také ukazuje, jak číst hodnoty tagů a jak přidávat tagy do prezentace, jednotlivého snímku nebo tvaru. Kromě toho článek pokrývá běžné úlohy správy tagů, jako je vymazání všech tagů, odstranění tagu podle názvu a získání seznamu názvů tagů.

## **Ukládání dat v souborech prezentací**

Soubory PPTX — položky s příponou .pptx — jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Formát Office Open XML definuje strukturu dat obsažených v prezentacích. 

S *snímkem* jako jedním z prvků v prezentacích obsahuje *část snímku* obsah jednoho snímku. Část snímku může mít explicitní vztahy k mnoha částem — například User Defined Tags — definované standardem ISO/IEC 29500. 

Vlastní data (specifická pro prezentaci) nebo uživatel mohou existovat jako tagy ([ITagCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/itagcollection/)) a CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 
Tagy jsou v podstatě páry řetězcových klíč‑hodnota. 
{{% /alert %}} 

## **Získání hodnot tagů**

V prezentacích odpovídá tag vlastnosti IDocumentProperties.Keywords. Tento ukázkový kód ukazuje, jak získat hodnotu tagu pomocí Aspose.Slides for Python via .NET pro [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **Přidání tagů do prezentací**

Aspose.Slides umožňuje přidávat tagy do prezentací. Tag obvykle sestává ze dvou položek: 

- název vlastní vlastnosti - `MyTag` 
- hodnota vlastní vlastnosti - `My Tag Value`

Pokud potřebujete klasifikovat některé prezentace podle konkrétního pravidla nebo vlastnosti, může být pro vás užitečné přidat tagy k těmto prezentacím. Například pokud chcete kategorizovat nebo seskupit všechny prezentace ze zemí Severní Ameriky, můžete vytvořit tag „North American“ a přiřadit jako hodnoty relevantní země (USA, Mexiko a Kanada). 

Tento ukázkový kód ukazuje, jak přidat tag k [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) pomocí Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Tagy lze také nastavit pro [Slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

Nebo pro jakýkoli jednotlivý [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Omezení**

Tagy přidané prostřednictvím kolekce `custom_data.tags` jsou uloženy pouze v souboru PowerPoint. **Nejsou** přeneseny do struktury tagů PDF při exportu prezentace do PDF. V důsledku toho nelze získat vlastní identifikátor přiřazený jako tag z označeného PDF.

**Workaround**: Můžete uložit vlastní identifikátor do **Alt Text** objektu (např. `shape.alternative_text = "MyId"`). Po exportu do PDF se Alt Text může objevit ve struktuře tagů PDF.

## **Často kladené otázky**

**Mohu odstranit všechny tagy z prezentace, snímku nebo objektu najednou?**

Ano. [Tag collection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/tagcollection/) podporuje operaci [clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides/tagcollection/clear/), která najednou smaže všechny páry klíč‑hodnota.

**Jak mohu smazat jediný tag podle jeho názvu, aniž bych procházel celou kolekci?**

Použijte operaci [remove(name)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/tagcollection/remove/) na [TagCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/tagcollection/) k odstranění tagu podle jeho klíče.

**Jak mohu získat úplný seznam názvů tagů pro analytiku nebo filtrování?**

Použijte [get_names_of_tags](https://reference.aspose.com/slides/cs/python-net/aspose.slides/tagcollection/get_names_of_tags/) na [tag collection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/tagcollection/); vrátí pole se všemi názvy tagů.