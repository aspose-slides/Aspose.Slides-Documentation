---
title: Sekwencja wyboru czcionek w Aspose.Slides dla Java
linktitle: Wybór czcionki
type: docs
weight: 80
url: /pl/java/font-selection-sequence/
keywords:
- wybór czcionki
- substytucja czcionki
- zastępowanie czcionki
- reguła substytucji
- dostępna czcionka
- brakująca czcionka
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides dla Java wybiera czcionki, zapewniając wyraźną i spójną prezentację plików PPT, PPTX i ODP — popraw swoje slajdy już teraz."
---
## **Przegląd**

Gdy prezentacja jest ładowana, renderowana lub konwertowana do innego formatu, Aspose.Slides sprawdza, czy czcionki użyte w prezentacji są dostępne w systemie operacyjnym. Jeśli wymagana czcionka jest brakująca, Aspose.Slides wybiera czcionkę zastępczą, która jest jak najbardziej zbliżona do tej, której użyłby PowerPoint.

Aspose.Slides najpierw wyszukuje wybraną czcionkę w systemie operacyjnym. Jeśli czcionka zostanie znaleziona, jest używana. Jeśli nie zostanie znaleziona, stosowana jest odpowiednia czcionka zastępcza. Gdy reguły substytucji czcionek są zdefiniowane przy użyciu `FontSubstRule`, reguły te również są brane pod uwagę.

Możesz także dodać czcionki w czasie działania aplikacji, używać osadzonych czcionek z prezentacji lub ładować czcionki zewnętrzne dla dokumentów wyjściowych, takich jak pliki PDF.

## **Wybór czcionki**

Na czcionki w prezentacji obowiązują określone zasady, gdy prezentacja jest ładowana, renderowana lub konwertowana do innego formatu. Na przykład, gdy próbujesz przekonwertować prezentację (jej slajdy) na obrazy, czcionki prezentacji są sprawdzane pod kątem dostępności wybranych czcionek w systemie operacyjnym. Jeśli czcionki zostaną potwierdzone jako brakujące, są zastępowane — zobacz [**Zastępowanie czcionek**](https://docs.aspose.com/slides/pl/java/font-replacement/) i [**Substytucja czcionek**](https://docs.aspose.com/slides/pl/java/font-substitution/).

Oto proces, który Aspose.Slides stosuje przy obsłudze czcionek:

1. Aspose.Slides wyszukuje czcionki w systemie operacyjnym, aby znaleźć czcionkę pasującą do wybranej w prezentacji. 
2. Jeśli wybrana czcionka zostanie znaleziona, Aspose.Slides ją używa. W przeciwnym razie Aspose.Slides używa czcionki zastępczej, która jest jak najbardziej zbliżona do tej, której użyłby PowerPoint.
3. Jeśli reguły zastępowania czcionek zostały ustawione przy użyciu [FontSubstRule](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsubstrule/), zostają zastosowane. 

Aspose.Slides umożliwia dodanie czcionek w czasie działania aplikacji i ich późniejsze użycie. Zobacz [**Czcionki niestandardowe**](https://docs.aspose.com/slides/pl/java/custom-font/). 

Gdy dodatkowe czcionki są umieszczane w prezentacji, nazywa się je [**Czcionki osadzone**](https://docs.aspose.com/slides/pl/java/embedded-font/).

Aspose.Slides pozwala dodać czcionki, które są stosowane *tylko* w dokumentach wyjściowych. Na przykład, jeśli prezentacja, którą chcesz przekonwertować na PDF, zawiera czcionki brakujące w twoim systemie i czcionki osadzone, możesz dodać lub załadować potrzebne czcionki jako **czcionki zewnętrzne**. 

{{% alert title="Note" color="info" %}} 
Nie dystrybuujemy żadnych czcionek, ani płatnych, ani darmowych. Nasze API umożliwia ładowanie czcionek zewnętrznych i osadzanie ich w dokumentach, ale robisz to na własną odpowiedzialność i według własnego uznania.
{{% /alert %}}

## **FAQ**

### Jak mogę określić, które czcionki są faktycznie używane w prezentacji przed konwersją?

Aspose.Slides umożliwia przeglądanie używanych czcionek za pomocą [menedżera czcionek](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsmanager/), dzięki czemu możesz zdecydować, czy [osadzić](/slides/pl/java/embedded-font/), [zastąpić](/slides/pl/java/font-replacement/), czy dodać [zewnętrzne źródła](/slides/pl/java/custom-font/). To pomaga zapobiegać niechcianym zamianom podczas renderowania i eksportu.

### Czy mogę dodać dodatkowe katalogi czcionek bez instalowania ich w systemie operacyjnym?

Tak. Możesz zarejestrować [zewnętrzne źródła czcionek](/slides/pl/java/custom-font/), takie jak foldery lub strumienie w pamięci, do renderowania i eksportu. To usuwa zależność od czcionek systemu hosta i zapewnia przewidywalny układ.

### Jak zapobiec cichej zmianie na nieodpowiednią czcionkę, gdy brakujący glif?

Zdefiniuj wcześniej wyraźne [zastępowanie czcionek](/slides/pl/java/font-replacement/) oraz [reguły awaryjne czcionek](/slides/pl/java/fallback-font/). Analizując używane czcionki i ustalając kontrolowany priorytet zastępstw, zapewniasz spójną typografię i unikasz nieoczekiwanych rezultatów.