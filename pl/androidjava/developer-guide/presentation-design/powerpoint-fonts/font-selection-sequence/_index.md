---
title: Sekwencja wyboru czcionek w Aspose.Slides dla Androida za pomocą Java
linktitle: Wybór czcionek
type: docs
weight: 80
url: /pl/androidjava/font-selection-sequence/
keywords:
- wybór czcionek
- zastępowanie czcionek
- zamiana czcionek
- reguła zastępowania
- dostępna czcionka
- brakująca czcionka
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides dla Androida za pomocą Java wybiera czcionki, zapewniając wyraźną i spójną prezentację plików PPT, PPTX i ODP — popraw swoje slajdy już teraz."
---
## **Przegląd**

Gdy prezentacja jest wczytywana, renderowana lub konwertowana do innego formatu, Aspose.Slides sprawdza, czy czcionki użyte w prezentacji są dostępne w systemie operacyjnym. Jeśli wymagana czcionka jest nieobecna, Aspose.Slides wybiera czcionkę zastępczą, która jest jak najbardziej zbliżona do tej, którą używałby PowerPoint.

Aspose.Slides najpierw przeszukuje system operacyjny w poszukiwaniu wybranej czcionki. Jeśli czcionka zostanie znaleziona, jest używana. Jeśli nie zostanie znaleziona, zastosowana zostaje odpowiednia czcionka zastępcza. Gdy reguły podstawiania czcionek są zdefiniowane za pomocą `FontSubstRule`, są one również uwzględniane.

Możesz także dodać czcionki w czasie działania aplikacji, używać czcionek osadzonych w prezentacji lub wczytać czcionki zewnętrzne do dokumentów wyjściowych, takich jak pliki PDF.

## **Wybór czcionki**

Na czcionki w prezentacji obowiązują określone reguły podczas wczytywania, renderowania lub konwertowania prezentacji do innego formatu. Na przykład, gdy próbujesz konwertować prezentację (jej slajdy) na obrazy, czcionki prezentacji są sprawdzane, aby zweryfikować, czy wybrane czcionki są dostępne w systemie operacyjnym. Jeśli czcionki zostaną potwierdzone jako nieobecne, zostają zastąpione — zobacz [**Font Replacement**](https://docs.aspose.com/slides/pl/androidjava/font-replacement/) i [**Font Substitution**](https://docs.aspose.com/slides/pl/androidjava/font-substitution/).

Oto proces, który Aspose.Slides stosuje przy obsłudze czcionek:

1. Aspose.Slides przeszukuje system operacyjny w poszukiwaniu czcionki, która pasuje do wybranej czcionki w prezentacji. 
2. Jeśli wybrana czcionka zostanie znaleziona, Aspose.Slides jej używa. W przeciwnym razie Aspose.Slides używa czcionki zastępczej, która jest jak najbardziej zbliżona do tej, którą użyłby PowerPoint. 
3. Jeśli reguły zastępowania czcionek zostały ustawione za pomocą [FontSubstRule](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsubstrule/), są one stosowane.

Aspose.Slides pozwala dodać czcionki w czasie działania aplikacji i następnie ich używać. Zobacz [**Custom fonts**](https://docs.aspose.com/slides/pl/androidjava/custom-font/).

Gdy dodatkowe czcionki są umieszczane w prezentacji, nazywa się je [**Embedded fonts**](https://docs.aspose.com/slides/pl/androidjava/embedded-font/).

Aspose.Slides pozwala dodać czcionki, które są stosowane wyłącznie w dokumentach wyjściowych. Na przykład, jeśli prezentacja, którą chcesz przekonwertować na PDF, zawiera czcionki nieobecne w twoim systemie i czcionki osadzone, możesz dodać lub wczytać potrzebne czcionki jako **external fonts**. 

{{% alert title="Note" color="primary" %}} 
Nie rozpowszechniamy żadnych czcionek, ani płatnych, ani darmowych. Nasze API umożliwia wczytywanie czcionek zewnętrznych i osadzanie ich w dokumentach, ale robisz to na własny wybór i odpowiedzialność.
{{% /alert %}}

## **FAQ**

**Jak mogę określić, które czcionki są faktycznie używane w prezentacji przed konwersją?**

Aspose.Slides umożliwia sprawdzenie używanych czcionek za pośrednictwem [font manager](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsmanager/), dzięki czemu możesz zdecydować, czy [embed](/slides/pl/androidjava/embedded-font/), [replace](/slides/pl/androidjava/font-replacement/) lub dodać [external sources](/slides/pl/androidjava/custom-font/). To pomaga zapobiegać niechcianym podstawieniom podczas renderowania i eksportu.

**Czy mogę dodać dodatkowe katalogi z czcionkami bez instalowania ich w systemie operacyjnym?**

Tak. Możesz zarejestrować [external font sources](/slides/pl/androidjava/custom-font/) takie jak foldery lub strumienie w pamięci do renderowania i eksportu. Usuwa to zależność od czcionek systemowych i zapewnia przewidywalny układ.

**Jak zapobiec cichej zmianie na nieodpowiednią czcionkę, gdy brakuje glifu?**

Zdefiniuj wcześniej explicite [font replacement](/slides/pl/androidjava/font-replacement/) oraz reguły [fallback-font](/slides/pl/androidjava/fallback-font/). Analizując używane czcionki i ustalając kontrolowaną kolejność priorytetów zastępników, zapewniasz spójną typografię i unikasz nieoczekiwanych rezultatów.