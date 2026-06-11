---
title: Sekwencja wyboru czcionek w Aspose.Slides dla .NET
linktitle: Wybór czcionek
type: docs
weight: 80
url: /pl/net/font-selection-sequence/
keywords:
- wybór czcionek
- substytucja czcionek
- zastąpienie czcionek
- reguła substytucji
- dostępna czcionka
- brakująca czcionka
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides dla .NET wybiera czcionki, zapewniając wyraźną i spójną prezentację plików PPT, PPTX i ODP — popraw swoje slajdy już teraz."
---
## **Przegląd**

Kiedy prezentacja jest ładowana, renderowana lub konwertowana do innego formatu, Aspose.Slides sprawdza, czy czcionki użyte w prezentacji są dostępne w systemie operacyjnym. Jeśli wymagana czcionka brakuje, Aspose.Slides wybiera czcionkę zastępczą, która jest jak najbardziej zbliżona do tej, której użyłby PowerPoint.

Aspose.Slides najpierw wyszukuje wybraną czcionkę w systemie operacyjnym. Jeśli czcionka zostanie znaleziona, jest używana. Jeśli nie, stosowana jest odpowiednia czcionka zastępcza. Gdy reguły zastępowania czcionek są określone przy pomocy `FontSubstRule`, są one również brane pod uwagę.

Można także dodać czcionki w czasie działania aplikacji, używać czcionek osadzonych w prezentacji lub wczytywać zewnętrzne czcionki dla dokumentów wyjściowych, takich jak pliki PDF.

## **Wybór czcionek**

Na czcionki w prezentacji obowiązują pewne reguły podczas ładowania, renderowania lub konwersji do innego formatu. Na przykład przy konwersji prezentacji (jej slajdów) do obrazów, czcionki prezentacji są sprawdzane pod kątem dostępności w systemie operacyjnym. Jeśli czcionki zostaną potwierdzone jako nieobecne, są zamieniane — zobacz [**Zastąpienie czcionek**](https://docs.aspose.com/slides/pl/net/font-replacement/) i [**Substitucja czcionek**](https://docs.aspose.com/slides/pl/net/font-substitution/).

Oto proces, którego Aspose.Slides używa przy obsłudze czcionek:

1. Aspose.Slides wyszukuje czcionki w systemie operacyjnym, aby znaleźć czcionkę pasującą do wybranej w prezentacji. 
2. Jeśli wybrana czcionka zostanie znaleziona, Aspose.Slides ją używa. W przeciwnym razie Aspose.Slides korzysta z czcionki zastępczej, jak najbardziej zbliżonej do tej, której użyłby PowerPoint.
3. Jeśli reguły zastępowania czcionek zostały ustawione przy pomocy [FontSubstRule](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsubstrule/), są one stosowane. 

Aspose.Slides umożliwia dodanie czcionek w czasie działania aplikacji i ich późniejsze użycie. Zobacz [**Czcionki niestandardowe**](https://docs.aspose.com/slides/pl/net/custom-font/). 

Gdy dodatkowe czcionki są umieszczane w prezentacji, nazywane są one [**Czcionkami osadzonymi**](https://docs.aspose.com/slides/pl/net/embedded-font/).

Aspose.Slides pozwala dodać czcionki, które są stosowane *wyłącznie* w dokumentach wyjściowych. Na przykład, jeśli prezentacja, którą chcesz przekonwertować do PDF, zawiera czcionki brakujące w twoim systemie i brak osadzonych czcionek, możesz dodać lub wczytać potrzebne czcionki jako **czcionki zewnętrzne**. 

{{% alert title="Uwaga" color="primary" %}} 
Nie rozpowszechniamy żadnych czcionek, ani płatnych, ani darmowych. Nasze API umożliwia wczytywanie czcionek zewnętrznych i osadzanie ich w dokumentach, ale robisz to na własną decyzję i odpowiedzialność. 
{{% /alert %}}

## **FAQ**

**Jak mogę określić, które czcionki są faktycznie używane w prezentacji przed konwersją?**

Aspose.Slides umożliwia przeglądanie używanych czcionek za pośrednictwem [menedżera czcionek](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/fontsmanager/), dzięki czemu możesz zdecydować, czy [osadzić](/slides/pl/net/embedded-font/), [zamienić](/slides/pl/net/font-replacement/) lub dodać [zewnętrzne źródła](/slides/pl/net/custom-font/). To pomaga zapobiegać niechcianym substytucjom podczas renderowania i eksportu.

**Czy mogę dodać dodatkowe katalogi czcionek bez instalowania ich w systemie operacyjnym?**

Tak. Możesz zarejestrować [zewnętrzne źródła czcionek](/slides/pl/net/custom-font/), takie jak foldery lub strumienie w pamięci, do renderowania i eksportu. Dzięki temu unikasz zależności od czcionek systemowych i utrzymujesz przewidywalny układ.

**Jak zapobiec cichej zmianie na nieodpowiednią czcionkę, gdy brakuje glifu?**

Zdefiniuj wcześniej wyraźne [zastąpienie czcionek](/slides/pl/net/font-replacement/) oraz reguły [fallback czcionek](/slides/pl/net/fallback-font/). Analizując używane czcionki i ustawiając kontrolowaną priorytetyzację zamienników, zapewniasz spójną typografię i unikniesz nieoczekiwanych rezultatów.