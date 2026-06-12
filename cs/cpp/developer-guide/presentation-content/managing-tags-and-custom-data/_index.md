---
title: Správa tagů a vlastních dat v prezentacích pomocí C++
linktitle: Tagy a vlastní data
type: docs
weight: 300
url: /cs/cpp/managing-tags-and-custom-data/
keywords:
- vlastnosti dokumentu
- značka
- vlastní data
- přidat značku
- párové hodnoty
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak přidávat, číst, aktualizovat a odstraňovat tagy a vlastní data v Aspose.Slides pro C++, s příklady pro prezentace PowerPoint a OpenDocument."
---
## **Overview**

Tento článek vysvětluje, jak Aspose.Slides pracuje s tagy a vlastními daty v prezentacích PowerPoint. Stručně popisuje, jak jsou data uložena v souborech PPTX, uvádí, že data specifická pro prezentaci mohou existovat jako tagy a vlastní XML části, a popisuje tagy jako páry řetězcových klíč‑hodnota.

Také ukazuje, jak číst hodnoty tagů a jak přidávat tagy do prezentace, jednotlivého snímku nebo tvaru. Navíc článek pokrývá běžné úkoly správy tagů, jako je vymazání všech tagů, odstranění tagu podle názvu a získání seznamu názvů tagů.

## **Data Storage in Presentation Files**

Soubory PPTX — položky s příponou .pptx — jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Formát Office Open XML definuje strukturu dat obsažených v prezentacích. 

Protože *snímek* je jedním z prvků v prezentacích, *část snímku* obsahuje obsah jednoho snímku. Část snímku může mít explicitní vazby na mnoho částí — například uživatelem definované tagy — definované normou ISO/IEC 29500. 

Vlastní data (specifická pro prezentaci) nebo uživatel mohou existovat jako tagy ([ITagCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itagcollection/)) a CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 
Tagy jsou v podstatě páry řetězcových klíčů a hodnot. 
{{% /alert %}} 

## **Get Values of Tags**

V PowerPointu tag odpovídá vlastnosti IDocumentProperties.Keywords. Tento ukázkový kód vám ukazuje, jak získat hodnotu tagu pomocí Aspose.Slides pro C++ pro [Prezentace](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/):

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **Add Tags to Presentations**

Aspose.Slides vám umožňuje přidávat tagy do prezentací. Tag typicky sestává ze dvou položek: 

- název vlastní vlastnosti — `MyTag` 
- hodnota vlastní vlastnosti — `My Tag Value`

Pokud potřebujete klasifikovat některé prezentace podle konkrétního pravidla nebo vlastnosti, můžete využít přidání tagů k těmto prezentacím. Například pokud chcete seskupit všechny prezentace ze zemí Severní Ameriky, můžete vytvořit tag „North American“ a přiřadit jako hodnoty příslušné země (USA, Mexiko a Kanada). 

Tento ukázkový kód vám ukazuje, jak přidat tag k [Prezentaci](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) pomocí Aspose.Slides pro C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Tagy lze také nastavit pro [Snímek](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slide/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Nebo pro libovolný jednotlivý [Tvar](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Limitations**

Tagy přidané prostřednictvím kolekce vlastních dat tagů pomocí `get_CustomData()->get_Tags()` jsou uloženy pouze v souboru PowerPoint. **Nejsou** převedeny do struktury PDF tagů při exportu prezentace do PDF. V důsledku toho nelze vlastní identifikátor přiřazený jako tag získat z PDF s tagy.

**Obcházení**: Můžete uložit vlastní identifikátor do **Alt Text** objektu (např. `shape->set_AlternativeText(u"MyId")`). Po exportu do PDF se Alt Text může objevit ve struktuře PDF tagů.

## **FAQ**

**Mohu odstranit všechny tagy z prezentace, snímku nebo tvaru najednou?**

Ano. [Kolekce tagů](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/) podporuje operaci [clear](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/clear/), která najednou smaže všechny páry klíč‑hodnota.

**Jak mohu smazat jediný tag podle jeho názvu, aniž bych procházel celou kolekci?**

Použijte operaci [Remove(name)](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/remove/) na [TagCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/) k odstranění tagu podle jeho klíče.

**Jak mohu získat úplný seznam názvů tagů pro analýzu nebo filtrování?**

Použijte [GetNamesOfTags](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/getnamesoftags/) na [kolekci tagů](https://reference.aspose.com/slides/cs/cpp/aspose.slides/tagcollection/); vrátí pole se všemi názvy tagů.