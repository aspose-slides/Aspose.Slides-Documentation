---
title: Sekwencja wyboru czcionek w Aspose.Slides dla Node.js przy użyciu Java
linktitle: Wybór czcionek
type: docs
weight: 80
url: /pl/nodejs-java/font-selection-sequence/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Poznaj sposób, w jaki Aspose.Slides dla Node.js przy użyciu Java wybiera czcionki, zapewniając wyraźną i spójną prezentację plików PPT, PPTX i ODP - popraw swoje slajdy już teraz."
---
## **Przegląd**

Gdy prezentacja jest wczytywana, renderowana lub konwertowana na inny format, Aspose.Slides sprawdza, czy czcionki użyte w prezentacji są dostępne w systemie operacyjnym. Jeśli wymagana czcionka jest nieobecna, Aspose.Slides wybiera czcionkę zastępczą, która jest tak bliska, jak to możliwe temu, co używałby PowerPoint.

Aspose.Slides najpierw wyszukuje wybraną czcionkę w systemie operacyjnym. Jeśli czcionka zostanie znaleziona, jest używana. Jeśli nie zostanie znaleziona, stosowana jest odpowiednia czcionka zastępcza. Gdy reguły podstawiania czcionek są zdefiniowane przy użyciu `FontSubstRule`, są one również brane pod uwagę.

Możesz także dodać czcionki w czasie działania aplikacji, używać wbudowanych czcionek z prezentacji lub ładować czcionki zewnętrzne dla dokumentów wyjściowych, takich jak pliki PDF.

## **Wybór czcionki**

Na czcionki w prezentacji obowiązują określone reguły, gdy prezentacja jest wczytywana, renderowana lub konwertowana na inny format. Na przykład, gdy próbujesz przekonwertować prezentację (jej slajdy) na obrazy, czcionki prezentacji są sprawdzane, aby zweryfikować, czy wybrane czcionki są dostępne w systemie operacyjnym. Jeśli czcionki zostaną potwierdzone jako brakujące, są zastępowane — zobacz [**Font Replacement**](https://docs.aspose.com/slides/pl/nodejs-java/font-replacement/) i [**Font Substitution**](https://docs.aspose.com/slides/pl/nodejs-java/font-substitution/).

To jest proces, którego Aspose.Slides używa przy obsłudze czcionek:

1. Aspose.Slides przeszukuje czcionki w systemie operacyjnym, aby znaleźć czcionkę pasującą do wybranej w prezentacji czcionki. 
2. Jeśli wybrana czcionka zostanie znaleziona, Aspose.Slides jej używa. W przeciwnym razie Aspose.Slides używa czcionki zastępczej, która jest tak bliska, jak to możliwe temu, co używałby PowerPoint.
3. Jeśli reguły zastępowania czcionek zostały ustawione za pomocą [FontSubstRule](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsubstrule/), są one stosowane.

Aspose.Slides pozwala dodać czcionki w czasie działania aplikacji i następnie używać tych czcionek. Zobacz [**Custom fonts**](https://docs.aspose.com/slides/pl/nodejs-java/custom-font/).

Gdy dodatkowe czcionki są umieszczane w prezentacji, nazywa się je [**Embedded fonts**](https://docs.aspose.com/slides/pl/nodejs-java/embedded-font/).

Aspose.Slides pozwala dodać czcionki, które są stosowane wyłącznie w dokumentach wyjściowych. Na przykład, jeśli prezentacja, którą chcesz przekonwertować na PDF, zawiera czcionki brakujące w twoim systemie i wbudowane czcionki, możesz dodać lub załadować potrzebne czcionki jako **external fonts**.

{{% alert title="Note" color="primary" %}} 
Nie dystrybuujemy żadnych czcionek, zarówno płatnych, jak i darmowych. Nasze API umożliwia ładowanie czcionek zewnętrznych i osadzanie ich w dokumentach, ale robisz to na własny wybór i odpowiedzialność.
{{% /alert %}}

## **FAQ**

**Jak mogę określić, które czcionki są faktycznie używane w prezentacji przed konwersją?**

Aspose.Slides umożliwia przeglądanie używanych czcionek za pomocą [font manager](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/getfontsmanager/), dzięki czemu możesz zdecydować, czy [embed](/slides/pl/nodejs-java/embedded-font/), [replace](/slides/pl/nodejs-java/font-replacement/), czy dodać [external sources](/slides/pl/nodejs-java/custom-font/). To pomaga zapobiegać niechcianym podstawieniom podczas renderowania i eksportu.

**Czy mogę dodać dodatkowe katalogi czcionek bez instalowania ich w systemie operacyjnym?**

Tak. Możesz zarejestrować [external font sources](/slides/pl/nodejs-java/custom-font/) takie jak foldery lub strumienie w pamięci dla renderowania i eksportu. Usuwa to zależność od czcionek systemu gospodarza i utrzymuje układ przewidywalnym.

**Jak zapobiec cichej zamianie na nieodpowiednią czcionkę, gdy brakuje glifu?**

Zdefiniuj explicite [font replacement](/slides/pl/nodejs-java/font-replacement/) i reguły [fallBack rules](/slides/pl/nodejs-java/fallback-font/) z wyprzedzeniem. Analizując używane czcionki i ustawiając kontrolowany priorytet dla zamienników, zapewniasz spójną typografię i unikasz nieoczekiwanych rezultatów.