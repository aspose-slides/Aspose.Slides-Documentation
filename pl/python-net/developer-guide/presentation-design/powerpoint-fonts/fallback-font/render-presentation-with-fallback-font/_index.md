---
title: Renderowanie prezentacji z czcionkami zastępczymi w Pythonie
linktitle: Renderowanie prezentacji
type: docs
weight: 30
url: /pl/python-net/render-presentation-with-fallback-font/
keywords:
- czcionka zastępcza
- renderowanie PowerPoint
- renderowanie prezentacji
- renderowanie slajdu
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Renderuj prezentacje z czcionkami zastępczymi w Aspose.Slides dla Pythona poprzez .NET – zachowaj spójność tekstu w PPT, PPTX i ODP dzięki przykładowym kodom krok po kroku."
---
## **Przegląd**

Aspose.Slides umożliwia renderowanie prezentacji przy użyciu reguł czcionek zastępczych. Ten artykuł pokazuje, jak utworzyć kolekcję reguł czcionek zastępczych, modyfikować jej reguły poprzez usuwanie lub dodawanie czcionek zastępczych oraz przypisać kolekcję do właściwości `FontsManager.font_fall_back_rules_collection`.

Po przypisaniu kolekcji reguł czcionek zastępczych do `fonts_manager` prezentacji, reguły są stosowane podczas operacji takich jak zapisywanie, renderowanie i konwertowanie prezentacji. Przykład demonstruje, jak używać skonfigurowanych reguł przy renderowaniu miniatury slajdu i zapisywaniu jej jako obrazu PNG.

## **Renderowanie slajdu przy użyciu reguł czcionek zastępczych**

Poniższy przykład obejmuje następujące kroki:

1. Tworzymy [kolekcję reguł czcionek zastępczych](/slides/pl/python-net/create-fallback-fonts-collection/).
1. [Usuń](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontfallbackrule/remove/) regułę czcionki zastępczej i [add_fall_back_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) do innej reguły.
1. Ustaw kolekcję reguł w właściwości [FontsManager.font_fall_back_rules_collection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/).
1. Za pomocą metody [Presentation.save()](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) możemy zapisać prezentację w tym samym formacie lub w innym. Po ustawieniu kolekcji reguł czcionek zastępczych w FontsManager, reguły te są stosowane podczas wszelkich operacji na prezentacji: zapisywanie, renderowanie, konwertowanie itp.

```py
import aspose.slides as slides

# Utwórz nową instancję kolekcji reguł
rulesList = slides.FontFallBackRulesCollection()

# utwórz kilka reguł
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# Próba usunięcia czcionki zastępczej "Tahoma" z załadowanych reguł
	fallBackRule.remove("Tahoma")

	# I aktualizacja reguł dla określonego zakresu
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# Możemy także usunąć istniejące reguły z listy
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# Przypisanie przygotowanej listy reguł do użycia
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Renderowanie miniatury przy użyciu zainicjowanej kolekcji reguł i zapisanie jako PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert color="primary" %}} 
Dowiedz się więcej o tym, jak [konwertować slajdy PowerPoint na PNG w języku Python](/slides/pl/python-net/convert-powerpoint-to-png/).
{{% /alert %}}