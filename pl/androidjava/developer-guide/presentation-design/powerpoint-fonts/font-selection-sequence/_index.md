---
title: Sekwencja wyboru czcionek w Aspose.Slides dla Androida za pomocą Java
linktitle: Wybór czcionek
type: docs
weight: 80
url: /pl/androidjava/font-selection-sequence/
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
- Android
- Java
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides dla Androida za pomocą Java wybiera czcionki, zapewniając wyraźną i spójną prezentację plików PPT, PPTX i ODP — popraw teraz swoje slajdy."
---
## **Przegląd**

Gdy prezentacja jest ładowana, renderowana lub konwertowana na inny format, Aspose.Slides sprawdza, czy czcionki użyte w prezentacji są dostępne w systemie operacyjnym. Jeśli wymagana czcionka jest nieobecna, Aspose.Slides wybiera czcionkę zastępczą, która jest jak najbardziej zbliżona do tej, którą użyłby PowerPoint.

Aspose.Slides najpierw wyszukuje wybraną czcionkę w systemie operacyjnym. Jeśli czcionka zostanie znaleziona, jest używana. Jeśli nie zostanie znaleziona, zastosowana zostaje odpowiednia czcionka zastępcza. Gdy reguły podstawiania czcionek są zdefiniowane za pośrednictwem `FontSubstRule`, reguły te są również brane pod uwagę.

Można również dodać czcionki w czasie działania aplikacji, używać czcionek osadzonych w prezentacji lub ładować czcionki zewnętrzne dla dokumentów wyjściowych, takich jak pliki PDF.

## **Wybór czcionek**

Na czcionki w prezentacji obowiązują określone reguły, gdy prezentacja jest ładowana, renderowana lub konwertowana na inny format. Na przykład, gdy próbujesz przekonwertować prezentację (jej slajdy) na obrazy, czcionki prezentacji są sprawdzane pod kątem dostępności w systemie operacyjnym. Jeśli czcionki zostaną potwierdzone jako nieobecne, są zastępowane — zobacz [**Zastąpienie czcionek**](https://docs.aspose.com/slides/pl/androidjava/font-replacement/) oraz [**Podstawianie czcionek**](https://docs.aspose.com/slides/pl/androidjava/font-substitution/).

Oto proces, którego Aspose.Slides używa przy obsłudze czcionek:

1. Aspose.Slides wyszukuje czcionki w systemie operacyjnym, aby znaleźć czcionkę pasującą do wybranej w prezentacji.  
2. Jeśli wybrana czcionka zostanie znaleziona, Aspose.Slides ją używa. W przeciwnym razie Aspose.Slides stosuje czcionkę zastępczą, która jest jak najbardziej zbliżona do tej, którą użyłby PowerPoint.  
3. Jeśli reguły zastępowania czcionek zostały ustawione przez [FontSubstRule](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsubstrule/), są one stosowane.

Aspose.Slides pozwala dodać czcionki w czasie działania aplikacji i następnie ich używać. Zobacz [**Czcionki niestandardowe**](https://docs.aspose.com/slides/pl/androidjava/custom-font/).

Gdy dodatkowe czcionki zostaną umieszczone w prezentacji, nazywają się one [**Czcionki osadzone**](https://docs.aspose.com/slides/pl/androidjava/embedded-font/).

Aspose.Slides umożliwia dodanie czcionek, które są stosowane wyłącznie w dokumentach wyjściowych. Na przykład, jeśli prezentacja, którą chcesz przekonwertować na PDF, zawiera czcionki brakujące w Twoim systemie i czcionki osadzone, możesz dodać lub załadować potrzebne czcionki jako **zewnętrzne czcionki**. 

{{% alert title="Note" color="info" %}} 
Nie dystrybuujemy żadnych czcionek, płatnych ani darmowych. Nasze API pozwala ładować czcionki zewnętrzne i osadzać je w dokumentach, ale robisz to na własną odpowiedzialność i według własnego uznania.
{{% /alert %}}

## **FAQ**

### Jak mogę określić, które czcionki są faktycznie używane w prezentacji przed konwersją?

Aspose.Slides umożliwia przeglądanie używanych czcionek za pośrednictwem [menedżera czcionek](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsmanager/), dzięki czemu możesz zdecydować, czy [osadź](/slides/pl/androidjava/embedded-font/), [zastąp](/slides/pl/androidjava/font-replacement/) lub dodaj [zewnętrzne źródła](/slides/pl/androidjava/custom-font/). To pomaga zapobiegać niechcianym podstawieniom podczas renderowania i eksportu.

### Czy mogę dodać dodatkowe katalogi czcionek bez instalowania ich w systemie operacyjnym?

Tak. Możesz zarejestrować [zewnętrzne źródła czcionek](/slides/pl/androidjava/custom-font/) takie jak foldery lub strumienie w pamięci dla renderowania i eksportu. Usuwa to zależność od czcionek systemu hosta i utrzymuje układ przewidywalnym.

### Jak zapobiec cichej zmianie na nieodpowiednią czcionkę, gdy brakuje glifu?

Zdefiniuj wyraźnie [zastąpienie czcionki](/slides/pl/androidjava/font-replacement/) i reguły [zastępcze](/slides/pl/androidjava/fallback-font/) z wyprzedzeniem. Analizując używane czcionki i ustalając kontrolowany priorytet dla substytutów, zapewniasz spójną typografię i unikasz nieoczekiwanych rezultatów.