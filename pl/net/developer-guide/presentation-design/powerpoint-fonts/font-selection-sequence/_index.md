---
title: Sekwencja wyboru czcionek w Aspose.Slides dla .NET
linktitle: Wybór czcionek
type: docs
weight: 80
url: /pl/net/font-selection-sequence/
keywords:
- wybór czcionek
- podmiana czcionek
- zastąpienie czcionek
- reguła podmiany
- dostępna czcionka
- brakująca czcionka
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides dla .NET wybiera czcionki, zapewniając wyraźną, spójną prezentację plików PPT, PPTX i ODP — popraw teraz swoje slajdy."
---
## **Przegląd**

Gdy prezentacja jest ładowana, renderowana lub konwertowana do innego formatu, Aspose.Slides sprawdza, czy czcionki użyte w prezentacji są dostępne w systemie operacyjnym. Jeśli wymagana czcionka jest nieobecna, Aspose.Slides wybiera czcionkę zastępczą, która jest jak najbliższa tej, której używa PowerPoint.

Aspose.Slides najpierw przeszukuje system operacyjny w poszukiwaniu wybranej czcionki. Jeśli czcionka zostanie znaleziona, jest używana. Jeśli nie zostanie znaleziona, zastosowana zostaje odpowiednia czcionka zastępcza. Gdy reguły podmiany czcionek są zdefiniowane poprzez `FontSubstRule`, są one również brane pod uwagę.

Możesz także dodać czcionki w czasie działania aplikacji, używać czcionek osadzonych w prezentacji lub wczytywać czcionki zewnętrzne dla dokumentów wyjściowych, takich jak pliki PDF.

## **Wybór czcionek**

Na czcionki w prezentacji obowiązują określone zasady podczas ładowania, renderowania lub konwertowania do innego formatu. Na przykład, gdy próbujesz przekonwertować prezentację (jej slajdy) na obrazy, czcionki prezentacji są sprawdzane pod kątem dostępności wybranych czcionek w systemie operacyjnym. Jeśli czcionki zostaną potwierdzone jako brakujące, zostają zastąpione — zobacz [**Zastąpienie czcionek**](https://docs.aspose.com/slides/pl/net/font-replacement/) i [**Podmiana czcionek**](https://docs.aspose.com/slides/pl/net/font-substitution/).

Oto proces, który Aspose.Slides stosuje przy obsłudze czcionek:

1. Aspose.Slides przeszukuje system operacyjny w poszukiwaniu czcionek, aby znaleźć czcionkę pasującą do wybranej w prezentacji. 
2. Jeśli wybrana czcionka zostanie znaleziona, Aspose.Slides jej używa. W przeciwnym razie Aspose.Slides używa czcionki zastępczej, która jest jak najbliższa tej, której używałby PowerPoint.
3. Jeśli reguły zastępowania czcionek zostały ustawione przy użyciu [FontSubstRule](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsubstrule/), zostają one zastosowane. 

Aspose.Slides umożliwia dodanie czcionek w czasie działania aplikacji i ich późniejsze użycie. Zobacz [**Czcionki niestandardowe**](https://docs.aspose.com/slides/pl/net/custom-font/). 

Gdy dodatkowe czcionki są umieszczone w prezentacji, nazywane są [**Czcionkami osadzonymi**](https://docs.aspose.com/slides/pl/net/embedded-font/).

Aspose.Slides umożliwia dodanie czcionek, które są stosowane wyłącznie w dokumentach wyjściowych. Na przykład, jeśli prezentacja, którą chcesz przekonwertować na PDF, zawiera czcionki brakujące w Twoim systemie i czcionki osadzone, możesz dodać lub wczytać potrzebne czcionki jako **czcionki zewnętrzne**. 

{{% alert title="Note" color="info" %}} 
Nie udostępniamy żadnych czcionek, zarówno płatnych, jak i darmowych. Nasze API pozwala wczytywać czcionki zewnętrzne i osadzać je w dokumentach, ale robisz to na własną odpowiedzialność i według własnego uznania.
{{% /alert %}}

## **FAQ**

### Jak mogę określić, które czcionki są faktycznie używane w prezentacji przed konwersją?

Aspose.Slides umożliwia przeglądanie używanych czcionek za pomocą [menedżera czcionek](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/fontsmanager/), dzięki czemu możesz zdecydować, czy [osadzić](/slides/pl/net/embedded-font/), [zastąpić](/slides/pl/net/font-replacement/), czy dodać [zewnętrzne źródła](/slides/pl/net/custom-font/). To pomaga zapobiegać niechcianym podmianom podczas renderowania i eksportu.

### Czy mogę dodać dodatkowe katalogi czcionek bez instalowania ich w systemie operacyjnym?

Tak. Możesz zarejestrować [zewnętrzne źródła czcionek](/slides/pl/net/custom-font/), takie jak foldery lub strumienie w pamięci, do renderowania i eksportu. Dzięki temu usuwa się zależność od czcionek systemu hosta i zachowuje przewidywalny układ.

### Jak zapobiec cichej zmianie na nieodpowiednią czcionkę, gdy brakuje glifu?

Zdefiniuj z góry wyraźne [zastąpienie czcionki](/slides/pl/net/font-replacement/) oraz reguły [fallback czcionek](/slides/pl/net/fallback-font/). Analizując używane czcionki i ustawiając kontrolowany priorytet dla zamienników, zapewniasz spójną typografię i unikasz nieoczekiwanych rezultatów.