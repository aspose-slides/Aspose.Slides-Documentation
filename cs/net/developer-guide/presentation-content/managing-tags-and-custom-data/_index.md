---
title: "Správa tagů a vlastních dat v prezentacích v .NET"
linktitle: "Tagy a vlastní data"
type: docs
weight: 300
url: /cs/net/managing-tags-and-custom-data/
keywords:
- "vlastnosti dokumentu"
- "tag"
- "vlastní data"
- "přidat tag"
- "párové hodnoty"
- "PowerPoint"
- "prezentace"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Naučte se, jak přidávat, číst, aktualizovat a odstraňovat tagy a vlastní data v Aspose.Slides pro .NET, s příklady pro prezentace PowerPoint a OpenDocument."
---
## **Přehled**

Tento článek vysvětluje, jak Aspose.Slides pracuje s tagy a vlastními daty v prezentacích PowerPoint. Stručně popisuje, jak jsou data uložena v souborech PPTX, upozorňuje, že data specifická pro prezentaci mohou existovat jako tagy a vlastní XML části, a popisuje tagy jako páry klíč‑hodnota typu řetězec.

Také ukazuje, jak číst hodnoty tagů a jak přidávat tagy do prezentace, jednotlivého snímku nebo objektu. Navíc článek pokrývá běžné úkoly správy tagů, jako je vymazání všech tagů, odstranění tagu podle názvu a získání seznamu názvů tagů.

## **Ukládání dat v souborech prezentací**

Soubory PPTX — položky s příponou .pptx — jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Formát Office Open XML definuje strukturu dat obsažených v prezentacích. 

U *snímku*, který je jedním z prvků v prezentacích, *část snímku* (slide part) obsahuje obsah jednoho snímku. Část snímku může mít explicitní vztahy k mnoha částem — například uživatelem definovaným tagům — definovaným podle ISO/IEC 29500. 

Vlastní data (specifická pro prezentaci) nebo uživatel mohou existovat jako tagy ([ITagCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/itagcollection)) a CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/icustomxmlpartcollection)). 

{{% alert color="primary" %}} 

Tagy jsou v podstatě páry klíč‑hodnota typu řetězec. 

{{% /alert %}} 

## **Získání hodnot tagů**

V aplikaci Slides odpovídá tag vlastnosti IDocumentProperties.Keywords. Tento ukázkový kód vám ukáže, jak získat hodnotu tagu pomocí Aspose.Slides pro .NET pro [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation):

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **Přidání tagů do prezentací**

Aspose.Slides vám umožňuje přidávat tagy do prezentací. Tag obvykle sestává ze dvou položek:

- název vlastní vlastnosti — `MyTag`
- hodnota vlastní vlastnosti — `My Tag Value`

Pokud potřebujete klasifikovat některé prezentace podle konkrétního pravidla nebo vlastnosti, můžete získat výhodu přidáním tagů do těchto prezentací. Například pokud chcete seskupit všechny prezentace ze severoamerických zemí, můžete vytvořit tag North American a přiřadit jako hodnoty příslušné země (USA, Mexiko a Kanada). 

Tento ukázkový kód vám ukáže, jak přidat tag do [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) pomocí Aspose.Slides pro .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Tagy lze také nastavit pro [Slide](https://reference.aspose.com/slides/cs/net/aspose.slides/slide):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

Nebo pro libovolný jednotlivý [Shape](https://reference.aspose.com/slides/cs/net/aspose.slides/shape):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **Omezení**

Tagy přidané pomocí kolekce `CustomData.Tags` jsou uloženy pouze v souboru PowerPoint. **Nejsou** přeneseny do struktury tagů PDF při exportu prezentace do PDF. V důsledku toho nelze získat vlastní identifikátor přiřazený jako tag z tagovaného PDF.

**Řešení**: Můžete uložit vlastní identifikátor do **Alt Textu** objektu (např. `shape.AlternativeText = "MyId"`). Po exportu do PDF se Alt Text může objevit ve struktuře tagů PDF.

## **Často kladené otázky**

**Mohu odstranit všechny tagy z prezentace, snímku nebo objektu jedním operací?**

Ano. [Kolekce tagů](https://reference.aspose.com/slides/cs/net/aspose.slides/tagcollection/) podporuje operaci [clear](https://reference.aspose.com/slides/cs/net/aspose.slides/tagcollection/clear/), která najednou odstraní všechny páry klíč‑hodnota.

**Jak mohu smazat jediný tag podle jeho názvu, aniž bych procházel celou kolekci?**

Použijte operaci [Remove(name)](https://reference.aspose.com/slides/cs/net/aspose.slides/tagcollection/remove/) na [TagCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/tagcollection/) k odstranění tagu podle jeho klíče.

**Jak mohu získat kompletní seznam názvů tagů pro analytiku nebo filtrování?**

Použijte [GetNamesOfTags](https://reference.aspose.com/slides/cs/net/aspose.slides/tagcollection/getnamesoftags/) na [kolekci tagů](https://reference.aspose.com/slides/cs/net/aspose.slides/tagcollection/); vrátí pole se všemi názvy tagů.