---
title: Sekwencja wyboru czcionek w Aspose.Slides dla Pythona
linktitle: Wybór czcionek
type: docs
weight: 80
url: /pl/python-net/font-selection-sequence/
keywords:
- wybór czcionek
- zastępowanie czcionek
- zamiana czcionek
- zasada zastępowania
- dostępna czcionka
- brakująca czcionka
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Poznaj, jak Aspose.Slides dla Pythona w środowisku .NET wybiera czcionki, zapewniając wyraźną i spójną prezentację plików PPT, PPTX i ODP — popraw swoje slajdy już teraz."
---
## **Przegląd**

Kiedy prezentacja jest ładowana, renderowana lub konwertowana do innego formatu, Aspose.Slides sprawdza, czy czcionki użyte w prezentacji są dostępne w systemie operacyjnym. Jeśli wymagana czcionka jest brakująca, Aspose.Slides wybiera czcionkę zastępczą, która jest tak bliska, jak to możliwe, tej, której użyłby PowerPoint.

Aspose.Slides najpierw wyszukuje wybraną czcionkę w systemie operacyjnym. Jeśli czcionka zostanie znaleziona, jest używana. Jeśli nie zostanie znaleziona, zastosowana zostaje odpowiednia czcionka zastępcza. Gdy zasady zamiany czcionek są zdefiniowane za pomocą `FontSubstRule`, te zasady są również brane pod uwagę.

Można również dodać czcionki w czasie działania aplikacji, używać wbudowanych czcionek z prezentacji lub wczytywać czcionki zewnętrzne dla dokumentów wyjściowych, takich jak pliki PDF.

## **Wybór czcionek**

Określone zasady dotyczą czcionek w prezentacji, gdy prezentacja jest ładowana, renderowana lub konwertowana do innego formatu. Na przykład, gdy próbujesz przekonwertować prezentację (jej slajdy) na obrazy, czcionki prezentacji są sprawdzane, aby zweryfikować, czy wybrane czcionki są dostępne w systemie operacyjnym. Jeśli czcionki zostaną potwierdzone jako brakujące, są zastępowane — zobacz [**Font Replacement**](https://docs.aspose.com/slides/pl/python-net/font-replacement/) i [**Font Substitution**](https://docs.aspose.com/slides/pl/python-net/font-substitution/).

Oto proces, którego Aspose.Slides używa przy obsłudze czcionek:

1. Aspose.Slides wyszukuje czcionki w systemie operacyjnym, aby znaleźć czcionkę pasującą do wybranej w prezentacji. 
2. Jeśli wybrana czcionka zostanie znaleziona, Aspose.Slides używa jej. W przeciwnym razie Aspose.Slides używa czcionki zastępczej, która jest tak bliska, jak to możliwe, tej, której użyłby PowerPoint.
3. Jeśli zasady zastępowania czcionek zostały ustawione za pomocą [FontSubstRule](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsubstrule/), są one zastosowane. 

Aspose.Slides pozwala dodać czcionki w czasie działania aplikacji i następnie używać tych czcionek. Zobacz [**Custom fonts**](https://docs.aspose.com/slides/pl/python-net/custom-font/). 

Kiedy dodatkowe czcionki są umieszczone w prezentacji, nazywają się one [**Embedded fonts**](https://docs.aspose.com/slides/pl/python-net/embedded-font/).

Aspose.Slides pozwala dodać czcionki, które są stosowane *tylko* w dokumentach wyjściowych. Na przykład, jeśli prezentacja, którą chcesz przekonwertować na PDF, zawiera czcionki brakujące w twoim systemie i czcionki wbudowane, możesz dodać lub wczytać potrzebne czcionki jako **external fonts**. 

{{% alert title="Note" color="primary" %}} 
Nie udostępniamy żadnych czcionek, ani płatnych, ani darmowych. Nasze API pozwala wczytywać czcionki zewnętrzne i osadzać je w dokumentach, ale robisz to na własny wybór i odpowiedzialność.
{{% /alert %}}

## **FAQ**

**Jak mogę określić, które czcionki są faktycznie użyte w prezentacji przed konwersją?**

Aspose.Slides pozwala sprawdzić użyte czcionki za pośrednictwem [font manager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/fonts_manager/), dzięki czemu możesz zdecydować, czy [embed](/slides/pl/python-net/embedded-font/), [replace](/slides/pl/python-net/font-replacement/) lub dodać [external sources](/slides/pl/python-net/custom-font/). To pomaga uniknąć niechcianych zamian podczas renderowania i eksportu.

**Czy mogę dodać dodatkowe katalogi czcionek bez instalowania ich w systemie operacyjnym?**

Tak. Możesz zarejestrować [external font sources](/slides/pl/python-net/custom-font/) takie jak foldery lub strumienie w pamięci dla renderowania i eksportu. Usuwa to zależność od czcionek systemowych i utrzymuje układ przewidywalnym.

**Jak zapobiec cichej zamianie na nieodpowiednią czcionkę, gdy brakujący glif?**

Zdefiniuj wyraźnie [font replacement](/slides/pl/python-net/font-replacement/) i reguły [fallBack rules](/slides/pl/python-net/fallback-font/) z wyprzedzeniem. Analizując użyte czcionki i ustawiając kontrolowany priorytet zamienników, zapewniasz spójną typografię i unikasz nieoczekiwanych rezultatów.