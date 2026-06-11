---
title: "Animuj tekst PowerPointa w C++"
linktitle: "Animowany tekst"
type: docs
weight: 60
url: /pl/cpp/animated-text/
keywords:
- "animowany tekst"
- "animacja tekstu"
- "animowany akapit"
- "animacja akapitu"
- "efekt animacji"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "C++"
- "Aspose.Slides"
description: "Twórz dynamiczny animowany tekst w prezentacjach PowerPoint i OpenDocument, korzystając z Aspose.Slides for C++, z łatwymi do śledzenia, zoptymalizowanymi przykładami kodu C++."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z animowanym tekstem w Aspose.Slides, stosując efekty animacji do poszczególnych akapitów oraz pobierając efekty już przypisane do akapitów w ramce tekstowej. Skupia się na metodach API używanych do dodawania animacji na poziomie akapitu oraz przeglądania istniejących efektów animacji akapitu w prezentacji.

## **Dodawanie efektów animacji do akapitów**

Dodaliśmy metodę [**AddEffect()**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) do klas [**Sequence**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.sequence) i [**ISequence**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.i_sequence). Metoda ta pozwala dodać efekty animacji do pojedynczego akapitu. Ten fragment kodu pokazuje, jak dodać efekt animacji do jednego akapitu:

``` cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// wybierz akapit, aby dodać efekt
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// dodaj efekt animacji Fly do wybranego akapitu
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```

## **Pobieranie efektów animacji dla akapitów**

Możesz chcieć dowiedzieć się, jakie efekty animacji zostały dodane do akapitu; na przykład w jednej sytuacji chcesz uzyskać efekty animacji w akapicie, ponieważ planujesz zastosować te efekty w innym akapicie lub kształcie.

Aspose.Slides for C++ umożliwia pobranie wszystkich efektów animacji zastosowanych do akapitów znajdujących się w ramce tekstowej (kształcie). Ten fragment kodu pokazuje, jak pobrać efekty animacji w akapicie:

``` cpp
String dataDir = GetDataPath();
auto pres = System::MakeObject<Presentation>(dataDir + u"Test.pptx");

auto sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(1));

for (auto paragraph : autoShape->get_TextFrame()->get_Paragraphs())
{
	auto effects = sequence->GetEffectsByParagraph(paragraph);

	if (effects->get_Length() > 0)
	{
		Console::WriteLine(String(u"Paragraph \"") + paragraph->get_Text() + u"\" has " + ObjectExt::ToString(effects[0]->get_Type()) + u" effect.");
	}
}
```

## **FAQ**

**Jak animacje tekstu różnią się od przejść slajdów i czy można je łączyć?**

Animacje tekstu kontrolują zachowanie obiektu w czasie na slajdzie, podczas gdy [transitions](/slides/pl/cpp/slide-transition/) kontrolują, jak zmieniają się slajdy. Są niezależne i można ich używać razem; kolejność odtwarzania jest regulowana przez oś czasu animacji oraz ustawienia przejścia.

**Czy animacje tekstu są zachowywane przy eksportowaniu do PDF lub obrazów?**

Nie. PDF i obrazy rastrowe są statyczne, więc zobaczysz pojedynczy stan slajdu bez ruchu. Aby zachować animację, użyj eksportu do [video](/slides/pl/cpp/convert-powerpoint-to-video/) lub [HTML](/slides/pl/cpp/export-to-html5/).

**Czy animacje tekstu działają w układach i masterze slajdów?**

Efekty zastosowane do obiektów układu/mastera są dziedziczone przez slajdy, ale ich czas i interakcja z animacjami na poziomie slajdu zależą od końcowej kolejności na slajdzie.