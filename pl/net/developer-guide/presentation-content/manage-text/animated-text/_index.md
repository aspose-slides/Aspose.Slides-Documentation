---
title: Animuj tekst PowerPoint w .NET
linktitle: Animowany tekst
type: docs
weight: 60
url: /pl/net/animated-text/
keywords:
- animowany tekst
- animacja tekstu
- animowany akapit
- animacja akapitu
- efekt animacji
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Utwórz dynamiczny animowany tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET, ze łatwymi do śledzenia, zoptymalizowanymi przykładami kodu C#."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z animowanym tekstem w Aspose.Slides, stosując efekty animacji do poszczególnych akapitów oraz pobierając efekty już przypisane do akapitów w ramce tekstowej. Skupia się na metodach API używanych do dodawania animacji na poziomie akapitu i przeglądania istniejących efektów animacji akapitów w prezentacji.

## **Dodaj efekty animacji do akapitów**

Dodaliśmy metodę [**AddEffect()**](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/sequence/methods/addeffect/index) do klas [**Sequence**](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/sequence) i [**ISequence**](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence). Metoda ta umożliwia dodanie efektów animacji do pojedynczego akapitu. Poniższy przykładowy kod pokazuje, jak dodać efekt animacji do jednego akapitu:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // wybierz akapit, aby dodać efekt
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // dodaj efekt animacji Fly do wybranego akapitu
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## **Pobierz efekty animacji dla akapitów**

Możesz chcieć dowiedzieć się, jakie efekty animacji zostały dodane do akapitu — na przykład w jednej sytuacji chcesz pobrać efekty animacji w akapicie, ponieważ planujesz zastosować je w innym akapicie lub obiekcie.

Aspose.Slides dla .NET umożliwia pobranie wszystkich efektów animacji zastosowanych do akapitów znajdujących się w ramce tekstowej (kształcie). Poniższy przykładowy kod pokazuje, jak pobrać efekty animacji w akapicie:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```

## **FAQ**

**Jak animacje tekstu różnią się od przejść slajdów i czy można je łączyć?**

Animacje tekstu sterują zachowaniem obiektu w czasie na slajdzie, podczas gdy [transitions](/slides/pl/net/slide-transition/) kontrolują sposób zmiany slajdów. Są niezależne i mogą być używane razem; kolejność odtwarzania jest zarządzana przez oś czasu animacji oraz ustawienia przejścia.

**Czy animacje tekstu są zachowywane przy eksportowaniu do PDF lub obrazów?**

Nie. PDF i obrazy rastrowe są statyczne, więc zobaczysz jedynie jeden stan slajdu bez ruchu. Aby zachować animację, użyj eksportu do [video](/slides/pl/net/convert-powerpoint-to-video/) lub [HTML](/slides/pl/net/export-to-html5/).

**Czy animacje tekstu działają w układach i w głównym szablonie slajdu?**

Efekty zastosowane do obiektów układu/głównego szablonu są dziedziczone przez slajdy, ale ich synchronizacja i interakcja z animacjami na poziomie slajdu zależą od ostatecznej kolejności na slajdzie.