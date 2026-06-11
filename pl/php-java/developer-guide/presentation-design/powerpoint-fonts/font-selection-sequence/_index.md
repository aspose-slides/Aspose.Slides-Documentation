---
title: Sekwencja wyboru czcionki w Aspose.Slides dla PHP
linktitle: Wybór czcionki
type: docs
weight: 80
url: /pl/php-java/font-selection-sequence/
keywords:
- wybór czcionki
- podstawianie czcionki
- zamiana czcionki
- reguła podstawiania
- dostępna czcionka
- brakująca czcionka
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides dla PHP poprzez Java wybiera czcionki, zapewniając wyraźną i spójną prezentację plików PPT, PPTX oraz ODP — ulepsz swoje slajdy już teraz."
---
## **Przegląd**

Gdy prezentacja jest ładowana, renderowana lub konwertowana do innego formatu, Aspose.Slides sprawdza, czy czcionki użyte w prezentacji są dostępne w systemie operacyjnym. Jeśli wymagana czcionka jest nieobecna, Aspose.Slides wybiera czcionkę zastępczą, która jest jak najbliższa tej, której używałby PowerPoint.

Aspose.Slides najpierw wyszukuje wybraną czcionkę w systemie operacyjnym. Jeśli czcionka zostanie znaleziona, jest używana. Jeśli nie zostanie znaleziona, stosowana jest odpowiednia czcionka zastępcza. Gdy reguły podstawiania czcionek są określone przy pomocy `FontSubstRule`, te reguły również są brane pod uwagę.

Możesz również dodać czcionki w czasie działania aplikacji, używać czcionek osadzonych w prezentacji lub ładować czcionki zewnętrzne dla dokumentów wyjściowych, takich jak pliki PDF.

## **Wybór czcionki**

Na czcionki w prezentacji mają zastosowanie określone reguły podczas ładowania, renderowania lub konwertowania prezentacji do innego formatu. Na przykład, gdy próbujesz przekonwertować prezentację (jej slajdy) na obrazy, czcionki prezentacji są sprawdzane, aby potwierdzić, że wybrane czcionki są dostępne w systemie operacyjnym. Jeśli czcionki zostaną uznane za brakujące, są zastępowane — zobacz [**Font Replacement**](https://docs.aspose.com/slides/pl/php-java/font-replacement/) i [**Font Substitution**](https://docs.aspose.com/slides/pl/php-java/font-substitution/).

Oto proces, który Aspose.Slides stosuje przy obsłudze czcionek:

1. Aspose.Slides wyszukuje czcionki w systemie operacyjnym, aby znaleźć czcionkę pasującą do wybranej w prezentacji. 
2. Jeśli wybrana czcionka zostanie znaleziona, Aspose.Slides jej używa. W przeciwnym razie Aspose.Slides używa czcionki zastępczej, która jest jak najbliższa tej, której używałby PowerPoint. 
3. Jeśli reguły zastępowania czcionek zostały ustawione przy pomocy [FontSubstRule](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsubstrule/), są one stosowane.

Aspose.Slides umożliwia dodanie czcionek do środowiska uruchomieniowego Aspose i późniejsze ich użycie. Zobacz [**Custom fonts**](https://docs.aspose.com/slides/pl/php-java/custom-font/).

Gdy dodatkowe czcionki zostaną umieszczone w prezentacji, nazywa się je [**Embedded fonts**](https://docs.aspose.com/slides/pl/php-java/embedded-font/).

Aspose.Slides umożliwia dodanie czcionek, które są stosowane wyłącznie w dokumentach wyjściowych. Na przykład, jeśli prezentacja, którą chcesz przekonwertować do PDF, zawiera czcionki nieobecne w Twoim systemie i czcionki osadzone, możesz dodać lub załadować potrzebne czcionki jako **External fonts**. 

## **FAQ**

**Jak mogę określić, które czcionki są rzeczywiście używane w prezentacji przed konwersją?**

Aspose.Slides umożliwia sprawdzenie używanych czcionek za pomocą [font manager](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/), dzięki czemu możesz zdecydować, czy [embed](/slides/pl/php-java/embedded-font/), [replace](/slides/pl/php-java/font-replacement/), czy dodać [external sources](/slides/pl/php-java/custom-font/). To pomaga zapobiec niechcianym podstawieniom podczas renderowania i eksportu.

**Czy mogę dodać dodatkowe katalogi czcionek bez instalowania ich w systemie operacyjnym?**

Tak. Możesz zarejestrować [external font sources](/slides/pl/php-java/custom-font/) takie jak foldery lub strumienie w pamięci dla renderowania i eksportu. Usuwa to zależność od czcionek systemowych i zapewnia przewidywalny układ.

**Jak zapobiec cichej zmianie na nieodpowiednią czcionkę, gdy brakuje glifu?**

Zdefiniuj wyraźnie [font replacement](/slides/pl/php-java/font-replacement/) oraz reguły [fallback rules](/slides/pl/php-java/fallback-font/) z wyprzedzeniem. Analizując używane czcionki i ustawiając kontrolowany priorytet dla zamienników, zapewniasz spójną typografię i unikasz nieoczekiwanych rezultatów.