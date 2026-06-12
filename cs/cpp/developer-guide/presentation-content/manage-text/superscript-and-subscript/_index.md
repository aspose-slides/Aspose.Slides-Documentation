---
title: Správa horního a dolního indexu v prezentacích pomocí C++
linktitle: Horní a dolní index
type: docs
weight: 80
url: /cs/cpp/superscript-and-subscript/
keywords:
- horní index
- dolní index
- přidat horní index
- přidat dolní index
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Ovládněte horní a dolní index v Aspose.Slides pro C++ a pozvedněte své prezentace profesionálním formátováním textu pro maximální dopad."
---
## **Přehled**

Aspose.Slides poskytuje funkce pro integraci textu s horním a dolním indexem do vašich prezentací PowerPoint (PPT, PPTX) a OpenDocument (ODP). Ať už potřebujete zvýraznit chemické vzorce, matematické rovnice nebo anotovat obsah pomocí poznámek pod čarou, tyto specializované možnosti formátování pomáhají udržet srozumitelnost a přesnost. V tomto článku se dozvíte, jak plynule aplikovat styly horního a dolního indexu a zajistit profesionální výsledek na každém snímku.

## **Správa textu s horním a dolním indexem**

Můžete přidávat text s horním a dolním indexem do libovolné části odstavce. Pro přidání textu s horním nebo dolním indexem v textovém rámečku Aspose.Slides je třeba použít **Escapement** vlastnosti třídy PortionFormat.

Tato vlastnost vrací nebo nastavuje text s horním nebo dolním indexem (hodnota od -100 % (dolní index) do 100 % (horní index)). Například:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
- Získejte odkaz na snímek pomocí jeho indexu.
- Přidejte IAutoShape typu Rectangle na snímek.
- Získejte ITextFrame spojený s IAutoShape.
- Vymažte existující odstavce
- Vytvořte nový objekt odstavce pro text s horním indexem a přidejte jej do kolekce IParagraphs v ITextFrame.
- Vytvořte nový objekt část
- Nastavte vlastnost Escapement pro část na hodnotu od 0 do 100 pro přidání horního indexu. (0 znamená žádný horní index)
- Nastavte text pro Portion a poté jej přidejte do kolekce částí odstavce.
- Vytvořte nový objekt odstavce pro text s dolním indexem a přidejte jej do kolekce IParagraphs v ITextFrame.
- Vytvořte nový objekt část
- Nastavte vlastnost Escapement pro část na hodnotu od 0 do -100 pro přidání dolního indexu. (0 znamená žádný dolní index)
- Nastavte text pro Portion a poté jej přidejte do kolekce částí odstavce.
- Uložte prezentaci jako soubor PPTX.

Implementace výše uvedených kroků je uvedena níže.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **Často kladené otázky**

**Zachová se horní a dolní index při exportu do PDF nebo jiných formátů?**

Ano, Aspose.Slides správně zachovává formátování horního a dolního indexu při exportu prezentací do PDF, PPT/PPTX, obrázků a dalších podporovaných formátů. Specializované formátování zůstává v všech výstupních souborech zachováno.

**Lze kombinovat horní a dolní index s dalšími formátovacími styly, jako je tučný nebo kurzíva?**

Ano, Aspose.Slides vám umožňuje kombinovat různé textové styly v rámci jedné části textu. Můžete povolit tučný, kurzívu, podtržení a současně použít horní nebo dolní index nastavením odpovídajících vlastností v [PortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/portionformat/) .

**Funguje formátování horního a dolního indexu pro text uvnitř tabulek, grafů nebo SmartArt?**

Ano, Aspose.Slides podporuje formátování ve většině objektů, včetně tabulek a prvků grafů. Při práci se SmartArt musíte získat přístup k odpovídajícím prvkům (například [SmartArtNode](https://reference.aspose.com/slides/cs/cpp/aspose.slides.smartart/smartartnode/)) a jejich textovým kontejnerům a poté nastavit vlastnosti [PortionFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/portionformat/) podobným způsobem.