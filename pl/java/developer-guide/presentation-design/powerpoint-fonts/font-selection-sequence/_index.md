---
title: Sekwencja wyboru czcionek w Aspose.Slides dla Javy
linktitle: Wybór czcionek
type: docs
weight: 80
url: /pl/java/font-selection-sequence/
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
- Java
- Aspose.Slides
description: "Dowiedz się, jak Aspose.Slides dla Javy wybiera czcionki, zapewniając wyraźną i spójną prezentację plików PPT, PPTX i ODP — popraw swoje slajdy już teraz."
---
## **Przegląd**

Gdy prezentacja jest ładowana, renderowana lub konwertowana do innego formatu, Aspose.Slides sprawdza, czy czcionki użyte w prezentacji są dostępne w systemie operacyjnym. Jeśli wymagana czcionka jest nieobecna, Aspose.Slides wybiera czcionkę zastępczą, która jest jak najbardziej podobna do tej, której używa PowerPoint.

Aspose.Slides najpierw przeszukuje system operacyjny w poszukiwaniu wybranej czcionki. Jeśli czcionka zostanie znaleziona, jest używana. Jeśli nie zostanie znaleziona, zastosowana zostaje odpowiednia czcionka zastępcza. Gdy reguły podstawiania czcionek są zdefiniowane za pomocą `FontSubstRule`, są one również brane pod uwagę.

Możesz także dodawać czcionki w trakcie działania aplikacji, używać osadzonych czcionek z prezentacji lub ładować zewnętrzne czcionki dla dokumentów wyjściowych, takich jak pliki PDF.

## **Wybór czcionek**

Określone reguły mają zastosowanie do czcionek w prezentacji, gdy jest ona ładowana, renderowana lub konwertowana do innego formatu. Na przykład, gdy próbujesz skonwertować prezentację (jej slajdy) na obrazy, czcionki z prezentacji są sprawdzane pod kątem dostępności wybranych czcionek w systemie operacyjnym. Jeśli czcionki zostaną potwierdzone jako brakujące, zostają zastąpione — zobacz [**Zastępowanie czcionek**](https://docs.aspose.com/slides/pl/java/font-replacement/) i [**Podstawianie czcionek**](https://docs.aspose.com/slides/pl/java/font-substitution/).

Oto proces, który Aspose.Slides stosuje przy obsłudze czcionek:

1. Aspose.Slides przeszukuje system operacyjny w poszukiwaniu czcionek, aby znaleźć czcionkę pasującą do wybranej w prezentacji. 
2. Jeśli wybrana czcionka zostanie znaleziona, Aspose.Slides ją używa. W przeciwnym razie Aspose.Slides używa czcionki zastępczej, która jest jak najbardziej zbliżona do tej, której używa PowerPoint.
3. Jeśli reguły zastępowania czcionek zostały ustawione za pośrednictwem [FontSubstRule](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsubstrule/), zostaną one zastosowane. 

Aspose.Slides umożliwia dodanie czcionek w czasie działania aplikacji i późniejsze ich użycie. Zobacz [**Czcionki niestandardowe**](https://docs.aspose.com/slides/pl/java/custom-font/). 

Gdy dodatkowe czcionki są umieszczone w prezentacji, nazywa się je [**Czcionkami osadzonymi**](https://docs.aspose.com/slides/pl/java/embedded-font/).

Aspose.Slides pozwala dodać czcionki, które są stosowane wyłącznie w dokumentach wyjściowych. Na przykład, jeśli prezentacja, którą chcesz skonwertować do formatu PDF, zawiera czcionki brakujące w Twoim systemie i czcionki osadzone, możesz dodać lub wczytać potrzebne czcionki jako **czcionki zewnętrzne**. 

{{% alert title="Uwaga" color="primary" %}} 
Nie dystrybuujemy żadnych czcionek, zarówno płatnych, jak i darmowych. Nasze API pozwala ładować czcionki zewnętrzne i osadzać je w dokumentach, ale robisz to na własny wybór i odpowiedzialność.
{{% /alert %}}

## **Najczęściej zadawane pytania**

**Jak mogę określić, które czcionki są rzeczywiście użyte w prezentacji przed konwersją?**

Aspose.Slides umożliwia przeglądanie używanych czcionek za pomocą [menedżera czcionek](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsmanager/), dzięki czemu możesz zdecydować, czy [osadzić](/slides/pl/java/embedded-font/), [zastąpić](/slides/pl/java/font-replacement/), czy dodać [zewnętrzne źródła](/slides/pl/java/custom-font/). Pomaga to zapobiegać niechcianym podstawieniom podczas renderowania i eksportu.

**Czy mogę dodać dodatkowe katalogi czcionek bez instalowania ich w systemie operacyjnym?**

Tak. Możesz zarejestrować [zewnętrzne źródła czcionek](/slides/pl/java/custom-font/), takie jak foldery lub strumienie w pamięci, do renderowania i eksportu. Usuwa to zależność od czcionek systemu hosta i utrzymuje przewidywalny układ.

**Jak zapobiec cichej zmianie na nieodpowiednią czcionkę, gdy brakuje glifu?**

Zdefiniuj wcześniej explicite [zastępowanie czcionek](/slides/pl/java/font-replacement/) oraz [reguły awaryjne czcionek](/slides/pl/java/fallback-font/). Analizując używane czcionki i ustalając kontrolowaną kolejność priorytetów dla substytutów, zapewniasz spójną typografię i unikasz nieoczekiwanych wyników.