---
title: Vykreslení prezentací s náhradními fonty v Pythonu přes Java
linktitle: Vykreslení prezentací
type: docs
weight: 30
url: /cs/python-java/render-presentation-with-fallback-font/
keywords:
- náhradní font
- vykreslit PowerPoint
- vykreslit prezentaci
- vykreslit snímek
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vykreslete prezentace s náhradními fonty v Aspose.Slides pro Python přes Java – zajistěte konzistentní text napříč PPT, PPTX a ODP pomocí podrobných ukázek kódu v Pythonu."
---
## **Přehled**

Aspose.Slides vám umožňuje vykreslovat prezentace pomocí pravidel náhradních fontů. Tento článek ukazuje, jak vytvořit kolekci pravidel náhradních fontů, upravit její pravidla odebráním nebo přidáním náhradních fontů a přiřadit kolekci pomocí metody [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection).

Jakmile je kolekce pravidel náhradních fontů přiřazena k [FontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/) prezentace, pravidla se použijí během operací, jako je ukládání, vykreslování a převod prezentace. Příklad demonstruje, jak použít nakonfigurovaná pravidla při vykreslování miniatury snímku a jejím uložení jako JPEG obrázek.

## **Vykreslení snímku pomocí pravidel náhradních fontů**

Následující příklad zahrnuje tyto kroky:

1. [Vytvořit kolekci pravidel náhradních fontů](/slides/cs/python-java/create-fallback-fonts-collection/).
1. [Odstranit](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontfallbackrule/#remove) náhradní font z pravidla a [přidat náhradní fonty](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) k jinému pravidlu.
1. Přiřadit kolekci pravidel pomocí [setFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) na správci fontů vráceném metodou [getFontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getFontsManager).
1. Použít metodu [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) k uložení prezentace ve stejném formátu nebo v jiném formátu. Po přiřazení kolekce pravidel náhradních fontů k [FontsManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/fontsmanager/) se tato pravidla aplikují během operací s prezentací: ukládání, vykreslování, převod atd.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# Vytvořte novou kolekci pravidel.
fallback_rules = FontFallBackRulesCollection()

# Vytvořte několik pravidel.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # Pokuste se odstranit náhradní font "Tahoma" z pravidel.
    fallback_rule.remove("Tahoma")

    # Aktualizujte pravidla pro zadaný rozsah.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# Odstraňte existující pravidlo, přičemž ponechte alespoň jedno pravidlo pro vykreslování.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # Přiřaďte připravenou kolekci pravidel.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # Vykreslete miniaturu pomocí nakonfigurované kolekce pravidel.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Uložte obrázek na disk ve formátu JPEG.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Přečtěte si více o tom, jak [convert PPT and PPTX to JPG in Python via Java](/slides/cs/python-java/convert-powerpoint-to-jpg/).
{{% /alert %}}