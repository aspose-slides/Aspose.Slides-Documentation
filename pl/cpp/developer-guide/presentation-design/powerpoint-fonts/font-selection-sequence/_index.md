---
title: Sekwencja wyboru czcionek w Aspose.Slides dla C++
linktitle: Wybór czcionek
type: docs
weight: 80
url: /pl/cpp/font-selection-sequence/
keywords:
- wybór czcionek
- podstawianie czcionek
- zastępowanie czcionek
- reguła podstawiania
- dostępna czcionka
- brakująca czcionka
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides dla C++ wybiera czcionki, zapewniając wyraźną i spójną prezentację plików PPT, PPTX i ODP - ulepsz swoje slajdy już teraz."
---
## **Przegląd**

Gdy prezentacja jest ładowana, renderowana lub konwertowana na inny format, Aspose.Slides sprawdza, czy czcionki użyte w prezentacji są dostępne w systemie operacyjnym. Jeśli wymagana czcionka jest brakująca, Aspose.Slides wybiera czcionkę zastępczą, która jest jak najbliższa tej, którą użyłby PowerPoint.

Aspose.Slides najpierw wyszukuje wybraną czcionkę w systemie operacyjnym. Jeśli czcionka zostanie znaleziona, jest używana. Jeśli nie zostanie znaleziona, stosowana jest odpowiednia czcionka zastępcza. Gdy reguły podstawiania czcionek są zdefiniowane za pomocą `FontSubstRule`, reguły te są również brane pod uwagę.

Możesz również dodać czcionki w czasie działania aplikacji, używać osadzonych czcionek z prezentacji lub wczytywać czcionki zewnętrzne dla dokumentów wyjściowych, takich jak pliki PDF.

## **Wybór czcionek**

Na czcionki w prezentacji mają zastosowanie określone reguły, gdy prezentacja jest ładowana, renderowana lub konwertowana na inny format. Na przykład, gdy próbujesz przekonwertować prezentację (jej slajdy) na obrazy, czcionki prezentacji są sprawdzane, aby zweryfikować, czy wybrane czcionki są dostępne w systemie operacyjnym. Jeśli czcionki zostaną potwierdzone jako brakujące, zostają zastąpione — zobacz [**Font Replacement**](https://docs.aspose.com/slides/pl/cpp/font-replacement/) i [**Font Substitution**](https://docs.aspose.com/slides/pl/cpp/font-substitution/).

Oto proces, który Aspose.Slides stosuje przy obsłudze czcionek:

1. Aspose.Slides wyszukuje czcionki w systemie operacyjnym, aby znaleźć czcionkę odpowiadającą wybranej w prezentacji. 
2. Jeśli wybrana czcionka zostanie znaleziona, Aspose.Slides ją używa. W przeciwnym razie Aspose.Slides używa czcionki zastępczej, która jest jak najbliższa tej, którą użyłby PowerPoint.
3. Jeśli reguły zastępowania czcionek zostały ustawione za pomocą [FontSubstRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsubstrule/), są one stosowane. 

Aspose.Slides pozwala dodać czcionki w czasie działania aplikacji i następnie je używać. Zobacz [**Custom fonts**](https://docs.aspose.com/slides/pl/cpp/custom-font/). 

Kiedy dodatkowe czcionki są umieszczane w prezentacji, nazywane są [**Embedded fonts**](https://docs.aspose.com/slides/pl/cpp/embedded-font/).

Aspose.Slides umożliwia dodanie czcionek, które są stosowane *tylko* w dokumentach wyjściowych. Na przykład, jeśli prezentacja, którą chcesz przekonwertować na PDF, zawiera czcionki brakujące w Twoim systemie i czcionki osadzone, możesz dodać lub wczytać potrzebne czcionki jako **external fonts**. 

{{% alert title="Note" color="primary" %}} 
Nie rozpowszechniamy żadnych czcionek, ani płatnych, ani darmowych. Nasze API umożliwia wczytywanie czcionek zewnętrznych i osadzanie ich w dokumentach, ale robisz to na własny wybór i odpowiedzialność.
{{% /alert %}}

## **FAQ**

**Jak mogę określić, które czcionki są faktycznie użyte w prezentacji przed konwersją?**

Aspose.Slides pozwala sprawdzić użyte czcionki za pomocą [font manager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_fontsmanager/), dzięki czemu możesz zdecydować, czy [embed](/slides/pl/cpp/embedded-font/), [replace](/slides/pl/cpp/font-replacement/), czy dodać [external sources](/slides/pl/cpp/custom-font/). To pomaga zapobiec niechcianym podstawieniom podczas renderowania i eksportu.

**Czy mogę dodać dodatkowe katalogi czcionek bez instalowania ich w systemie operacyjnym?**

Tak. Możesz zarejestrować [external font sources](/slides/pl/cpp/custom-font/) takie jak foldery lub strumienie w pamięci dla renderowania i eksportu. Usuwa to zależność od czcionek systemu hosta i utrzymuje układ przewidywalnym.

**Jak zapobiec cichej zamianie na nieodpowiednią czcionkę, gdy brakuje glifu?**

Zdefiniuj wyraźnie [font replacement](/slides/pl/cpp/font-replacement/) i reguły [fallBack](/slides/pl/cpp/fallback-font/) czcionek z wyprzedzeniem. Analizując użyte czcionki i ustawiając kontrolowany priorytet dla zamienników, zapewniasz spójną typografię i unikasz nieoczekiwanych rezultatów.