---
title: Ciąg wyboru czcionek w Aspose.Slides dla C++
linktitle: Wybór czcionek
type: docs
weight: 80
url: /pl/cpp/font-selection-sequence/
keywords:
- wybór czcionki
- podstawianie czcionek
- zamiana czcionek
- reguła podstawiania
- dostępna czcionka
- brakująca czcionka
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides for C++ wybiera czcionki, zapewniając wyraźną, spójną prezentację plików PPT, PPTX i ODP — popraw swoje slajdy już teraz."
---
## **Przegląd**

Gdy prezentacja jest ładowana, renderowana lub konwertowana do innego formatu, Aspose.Slides sprawdza, czy czcionki użyte w prezentacji są dostępne w systemie operacyjnym. Jeśli wymagana czcionka jest nieobecna, Aspose.Slides wybiera czcionkę zastępczą, która jest jak najbardziej zbliżona do tej, której użyłby PowerPoint.

Aspose.Slides najpierw przeszukuje system operacyjny w poszukiwaniu wybranej czcionki. Jeśli czcionka zostanie znaleziona, jest używana. Jeśli nie zostanie znaleziona, zastosowana zostaje odpowiednia czcionka zastępcza. Gdy reguły podstawiania czcionek są zdefiniowane za pomocą `FontSubstRule`, są one również brane pod uwagę.

Możesz także dodać czcionki w czasie działania aplikacji, używać czcionek osadzonych w prezentacji lub ładować czcionki zewnętrzne dla dokumentów wyjściowych, takich jak pliki PDF.

## **Wybór czcionki**

Na czcionki w prezentacji mają zastosowanie określone reguły, gdy prezentacja jest ładowana, renderowana lub konwertowana do innego formatu. Na przykład, gdy próbujesz konwertować prezentację (jej slajdy) na obrazy, czcionki prezentacji są sprawdzane pod kątem dostępności wybranych czcionek w systemie operacyjnym. Jeśli czcionki zostaną potwierdzone jako nieobecne, są zastępowane — zobacz [**Font Replacement**](https://docs.aspose.com/slides/pl/cpp/font-replacement/) i [**Font Substitution**](https://docs.aspose.com/slides/pl/cpp/font-substitution/).

Oto proces, który Aspose.Slides stosuje przy obsłudze czcionek:

1. Aspose.Slides przeszukuje system operacyjny w poszukiwaniu czcionki pasującej do wybranej w prezentacji czcionki. 
2. Jeśli wybrana czcionka zostanie znaleziona, Aspose.Slides ją używa. W przeciwnym razie Aspose.Slides używa czcionki zastępczej, która jest jak najbardziej podobna do tej, którą użyłby PowerPoint.
3. Jeśli reguły zastępowania czcionek zostały ustawione za pomocą [FontSubstRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsubstrule/), zostaną one zastosowane. 

Aspose.Slides pozwala dodać czcionki w czasie działania aplikacji i następnie używać tych czcionek. Zobacz [**Custom fonts**](https://docs.aspose.com/slides/pl/cpp/custom-font/). 

Gdy dodatkowe czcionki są umieszczane w prezentacji, nazywa się je [**Embedded fonts**](https://docs.aspose.com/slides/pl/cpp/embedded-font/).

Aspose.Slides umożliwia dodanie czcionek, które są stosowane wyłącznie w dokumentach wyjściowych. Na przykład, jeśli prezentacja, którą chcesz skonwertować do PDF, zawiera czcionki brakujące w Twoim systemie i czcionki osadzone, możesz dodać lub wczytać potrzebne czcionki jako **external fonts**. 

{{% alert title="Note" color="info" %}} 
Nie udostępniamy żadnych czcionek, ani płatnych, ani darmowych. Nasze API umożliwia wczytywanie czcionek zewnętrznych i osadzanie ich w dokumentach, ale robisz to na własny wybór i odpowiedzialność.
{{% /alert %}}

## **FAQ**

### Jak mogę określić, które czcionki są faktycznie używane w prezentacji przed konwersją?

Aspose.Slides umożliwia sprawdzenie używanych czcionek za pomocą [font manager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_fontsmanager/), dzięki czemu możesz zdecydować, czy [embed](/slides/pl/cpp/embedded-font/), [replace](/slides/pl/cpp/font-replacement/), czy dodać [external sources](/slides/pl/cpp/custom-font/). To pomaga zapobiegać niechcianym podstawieniom podczas renderowania i eksportu.

### Czy mogę dodać dodatkowe katalogi czcionek bez instalowania ich w systemie operacyjnym?

Tak. Możesz zarejestrować [external font sources](/slides/pl/cpp/custom-font/) takie jak foldery lub strumienie w pamięci do renderowania i eksportu. Usuwa to zależność od czcionek systemu hosta i zapewnia przewidywalny układ.

### Jak zapobiec cichej zmianie na nieodpowiednią czcionkę, gdy brakuje glifu?

Zdefiniuj wcześniej explicite [font replacement](/slides/pl/cpp/font-replacement/) oraz reguły [fallBack](/slides/pl/cpp/fallback-font/) czcionek. Analizując używane czcionki i ustalając kontrolowany priorytet substytutów, zapewniasz spójną typografię i unikasz nieoczekiwanych rezultatów.