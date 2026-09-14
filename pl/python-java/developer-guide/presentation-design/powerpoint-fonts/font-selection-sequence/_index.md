---
title: Sekwencja wyboru czcionek w Aspose.Slides dla Pythona przez Java
linktitle: Wybór czcionek
type: docs
weight: 80
url: /pl/python-java/font-selection-sequence/
keywords:
- wybór czcionek
- podstawianie czcionek
- zastąpienie czcionek
- reguła podstawiania
- dostępna czcionka
- brakująca czcionka
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides dla Pythona przez Java wybiera czcionki, zapewniając wyraźną i spójną prezentację plików PPT, PPTX i ODP — popraw teraz swoje slajdy."
---
## **Przegląd**

Gdy prezentacja jest ładowana, renderowana lub konwertowana do innego formatu, Aspose.Slides sprawdza, czy czcionki użyte w prezentacji są dostępne w systemie operacyjnym. Jeśli wymagana czcionka jest brakująca, Aspose.Slides wybiera czcionkę zastępczą, która jest tak bliska, jak to możliwe, tej używanej przez PowerPoint.

Aspose.Slides najpierw szuka wybranej czcionki w systemie operacyjnym. Jeśli czcionka zostanie znaleziona, jest używana. Jeśli nie zostanie znaleziona, stosowana jest odpowiednia czcionka zastępcza. Gdy reguły podstawiania czcionek są zdefiniowane przy użyciu [FontSubstRule](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsubstrule/), są one również brane pod uwagę.

Możesz również dodać czcionki w czasie działania aplikacji, używać osadzonych czcionek z prezentacji lub ładować czcionki zewnętrzne dla dokumentów wyjściowych, takich jak pliki PDF.

## **Wybór czcionki**

Na czcionki w prezentacji obowiązują określone zasady, gdy prezentacja jest ładowana, renderowana lub konwertowana do innego formatu. Na przykład, gdy próbujesz przekonwertować prezentację (jej slajdy) na obrazy, czcionki prezentacji są sprawdzane, aby zweryfikować, czy wybrane czcionki są dostępne w systemie operacyjnym. Jeśli czcionki zostaną potwierdzone jako brakujące, zostają zastąpione — zobacz [Font Replacement](/slides/pl/python-java/font-replacement/) i [Font Substitution](/slides/pl/python-java/font-substitution/).

Oto proces, którego Aspose.Slides używa przy obsłudze czcionek:

1. Aspose.Slides wyszukuje czcionki w systemie operacyjnym, aby znaleźć czcionkę pasującą do wybranej w prezentacji czcionki.
2. Jeśli wybrana czcionka zostanie znaleziona, Aspose.Slides jej używa. W przeciwnym razie Aspose.Slides używa czcionki zastępczej, która jest tak bliska, jak to możliwe, tej, której używa PowerPoint.
3. Jeśli reguły zastępowania czcionek zostały ustawione przy użyciu [FontSubstRule](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsubstrule/), zostaną zastosowane.

Aspose.Slides umożliwia dodanie czcionek w czasie działania aplikacji i późniejsze ich użycie. Zobacz [Custom fonts](/slides/pl/python-java/custom-font/).

Gdy dodatkowe czcionki są umieszczone w prezentacji, nazywa się je [Embedded fonts](/slides/pl/python-java/embedded-font/).

Aspose.Slides pozwala dodać czcionki, które są stosowane *tylko* w dokumentach wyjściowych. Na przykład, jeśli prezentacja, którą chcesz przekonwertować na PDF, używa czcionek, które nie są zainstalowane w systemie ani osadzone w prezentacji, możesz dodać lub załadować potrzebne czcionki jako **external fonts**.

{{% alert title="Uwaga" color="info" %}}
Nie dystrybuujemy żadnych czcionek, zarówno płatnych, jak i darmowych. Nasze API pozwala ładować czcionki zewnętrzne i osadzać je w dokumentach, ale robisz to na własną odpowiedzialność i według własnego uznania.
{{% /alert %}}

## **FAQ**

**Jak mogę określić, które czcionki są faktycznie używane w prezentacji przed konwersją?**

Aspose.Slides umożliwia przeglądanie używanych czcionek za pomocą [font manager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsmanager/), dzięki czemu możesz zdecydować, czy [embed](/slides/pl/python-java/embedded-font/), [replace](/slides/pl/python-java/font-replacement/), czy dodać [external sources](/slides/pl/python-java/custom-font/). To pomaga zapobiec niechcianym podstawieniom podczas renderowania i eksportu.

**Czy mogę dodać dodatkowe katalogi czcionek bez instalowania ich w systemie operacyjnym?**

Tak. Możesz zarejestrować [external font sources](/slides/pl/python-java/custom-font/) takie jak foldery lub strumienie w pamięci dla renderowania i eksportu. To eliminuje zależność od czcionek systemowych i zapewnia przewidywalny układ.

**Jak zapobiec cichej zamianie na nieodpowiednią czcionkę, gdy brakuje glifu?**

Zdefiniuj wyraźnie [font replacement](/slides/pl/python-java/font-replacement/) oraz reguły [fallback rules](/slides/pl/python-java/fallback-font/) z wyprzedzeniem. Analizując używane czcionki i ustawiając kontrolowaną priorytetowość zamienników, zapewniasz spójną typografię i unikasz nieoczekiwanych rezultatów.