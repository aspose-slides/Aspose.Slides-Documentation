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
description: "Odkryj, jak Aspose.Slides dla C++ wybiera czcionki, zapewniając ostre i spójne wyświetlanie plików PPT, PPTX i ODP — ulepsz swoje slajdy już teraz."
---
## **Przegląd**

Podczas ładowania, renderowania lub konwertowania prezentacji do innego formatu Aspose.Slides sprawdza, czy czcionki użyte w prezentacji są dostępne w systemie operacyjnym. Jeśli wymagana czcionka jest nieobecna, Aspose.Slides wybiera czcionkę zastępczą, która jest jak najbliższa tej, której użyłby PowerPoint.

Aspose.Slides najpierw wyszukuje wybraną czcionkę w systemie operacyjnym. Jeśli czcionka zostanie znaleziona, jest używana. Jeśli nie zostanie znaleziona, stosuje się odpowiednią czcionkę zastępczą. Gdy zasady podstawiania czcionek są określone za pośrednictwem `FontSubstRule`, zasady te są również brane pod uwagę.

Możesz również dodać czcionki w czasie działania aplikacji, używać czcionek osadzonych w prezentacji lub ładować czcionki zewnętrzne dla dokumentów wyjściowych, takich jak pliki PDF.

## **Wybór czcionki**

Na czcionki w prezentacji mają zastosowanie określone zasady, gdy prezentacja jest ładowana, renderowana lub konwertowana do innego formatu. Na przykład, gdy próbujesz przekonwertować prezentację (jej slajdy) na obrazy, czcionki prezentacji są sprawdzane, aby zweryfikować, czy wybrane czcionki są dostępne w systemie operacyjnym. Jeśli czcionki zostaną potwierdzone jako brakujące, zostają zastąpione — zobacz [**Font Replacement**](https://docs.aspose.com/slides/pl/cpp/font-replacement/) i [**Font Substitution**](https://docs.aspose.com/slides/pl/cpp/font-substitution/).

Jest to proces, którego Aspose.Slides używa przy obsłudze czcionek:

1. Aspose.Slides przeszukuje czcionki w systemie operacyjnym, aby znaleźć czcionkę pasującą do wybranej w prezentacji. 
2. Jeśli wybrana czcionka zostanie znaleziona, Aspose.Slides ją używa. W przeciwnym razie Aspose.Slides używa czcionki zastępczej, która jest jak najbliższa tej, której użyłby PowerPoint.
3. Jeśli zasady zastępowania czcionek zostały ustawione za pośrednictwem [FontSubstRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsubstrule/), są one stosowane. 

Aspose.Slides umożliwia dodanie czcionek w czasie działania aplikacji i ich późniejsze użycie. Zobacz [**Custom fonts**](https://docs.aspose.com/slides/pl/cpp/custom-font/). 

Kiedy dodatkowe czcionki są umieszczane w prezentacji, nazywane są [**Embedded fonts**](https://docs.aspose.com/slides/pl/cpp/embedded-font/).

Aspose.Slides umożliwia dodanie czcionek, które są stosowane wyłącznie do dokumentów wyjściowych. Na przykład, jeśli prezentacja, którą chcesz skonwertować do PDF, zawiera czcionki brakujące w Twoim systemie i czcionki osadzone, możesz dodać lub załadować potrzebne czcionki jako **external fonts**. 

{{% alert title="Note" color="primary" %}} 
Nie udostępniamy żadnych czcionek, ani płatnych, ani darmowych. Nasze API pozwala ładować czcionki zewnętrzne i osadzać je w dokumentach, ale robisz to na własny wybór i odpowiedzialność.
{{% /alert %}}

## **FAQ**

**Jak mogę określić, które czcionki są faktycznie używane w prezentacji przed konwersją?**

Aspose.Slides umożliwia sprawdzenie używanych czcionek za pomocą [font manager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_fontsmanager/), dzięki czemu możesz zdecydować, czy [embed](/slides/pl/cpp/embedded-font/), [replace](/slides/pl/cpp/font-replacement/) lub dodać [external sources](/slides/pl/cpp/custom-font/). Pomaga to zapobiec niechcianym podstawieniom podczas renderowania i eksportu.

**Czy mogę dodać dodatkowe katalogi czcionek bez instalowania ich w systemie operacyjnym?**

Tak. Możesz zarejestrować [external font sources](/slides/pl/cpp/custom-font/) takie jak foldery lub strumienie w pamięci dla renderowania i eksportu. Usuwa to zależność od czcionek systemu hosta i utrzymuje układ przewidywalnym.

**Jak zapobiec cichej zmianie na nieodpowiednią czcionkę, gdy brakuje glifu?**

Zdefiniuj wyraźnie [font replacement](/slides/pl/cpp/font-replacement/) oraz zasady [fallBack rules](/slides/pl/cpp/fallback-font/) z wyprzedzeniem. Analizując używane czcionki i ustawiając kontrolowany priorytet dla zamienników, zapewniasz spójną typografię i unikasz nieoczekiwanych rezultatów.