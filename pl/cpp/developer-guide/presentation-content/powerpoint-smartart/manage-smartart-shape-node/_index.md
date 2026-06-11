---
title: Zarządzanie węzłami kształtu SmartArt w prezentacjach przy użyciu C++
linktitle: Węzeł kształtu SmartArt
type: docs
weight: 30
url: /pl/cpp/manage-smartart-shape-node/
keywords:
- Węzeł SmartArt
- Węzeł podrzędny
- Dodaj węzeł
- Pozycja węzła
- Dostęp do węzła
- Usuń węzeł
- Niestandardowa pozycja
- Węzeł asystenta
- Format wypełnienia
- Renderowanie węzła
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Zarządzaj węzłami kształtu SmartArt w plikach PPT i PPTX przy użyciu Aspose.Slides dla C++. Uzyskaj przejrzyste przykłady kodu i wskazówki ułatwiające tworzenie prezentacji."
---
## **Przegląd**

Grafika SmartArt w prezentacjach PowerPoint jest organizowana za pomocą węzłów, które zawierają tekst i definiują strukturę diagramu. Aspose.Slides umożliwia programowe operowanie na tych węzłach SmartArt: dodawanie nowych węzłów i węzłów podrzędnych, wstawianie węzłów podrzędnych w określonej pozycji, dostęp do istniejących węzłów oraz odczyt ich tekstu, poziomu i pozycji.

Ten artykuł wyjaśnia, jak zarządzać węzłami kształtów SmartArt. Pokazuje, jak usuwać węzły, pracować z węzłami podrzędnymi według indeksu lub pozycji, zmienić węzeł asystenta na węzeł normalny, dostosować pozycję, rozmiar i obrót kształtów węzła SmartArt, ustawić format wypełnienia węzła oraz wygenerować miniaturkę dla węzła podrzędnego SmartArt.

## **Dodawanie węzła SmartArt**
Aspose.Slides for C++ udostępnia najprostsze API do zarządzania kształtami SmartArt w najłatwiejszy sposób. Poniższy przykładowy kod pomoże dodać węzeł i węzeł podrzędny wewnątrz kształtu SmartArt.

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) i wczytaj prezentację z kształtem SmartArt.  
- Pobierz referencję pierwszego slajdu, używając jego indeksu.  
- Przejdź przez wszystkie kształty znajdujące się na pierwszym slajdzie.  
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli tak jest.  
- Dodaj nowy węzeł do kolekcji NodeCollection kształtu SmartArt i ustaw tekst w TextFrame.  
- Następnie dodaj węzeł podrzędny do nowo dodanego węzła SmartArt i ustaw tekst w TextFrame.  
- Zapisz prezentację.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **Dodawanie węzła SmartArt w określonej pozycji**
W poniższym przykładzie wyjaśniono, jak dodać węzły podrzędne należące do poszczególnych węzłów kształtu SmartArt w wybranej pozycji.

- Utwórz instancję klasy `Presentation`.  
- Pobierz referencję pierwszego slajdu, używając jego indeksu.  
- Dodaj kształt SmartArt typu StackedList na wybranym slajdzie.  
- Uzyskaj dostęp do pierwszego węzła w dodanym kształcie SmartArt.  
- Dodaj węzeł podrzędny do wybranego węzła na pozycji 2 i ustaw jego tekst.  
- Zapisz prezentację.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **Dostęp do węzła SmartArt**
Poniższy przykładowy kod pomoże uzyskać dostęp do węzłów wewnątrz kształtu SmartArt. Należy pamiętać, że nie można zmienić właściwości LayoutType SmartArt, ponieważ jest ona tylko do odczytu i ustawia się ją wyłącznie w momencie dodania kształtu SmartArt.

- Utwórz instancję klasy `Presentation` i wczytaj prezentację z kształtem SmartArt.  
- Pobierz referencję pierwszego slajdu, używając jego indeksu.  
- Przejdź przez wszystkie kształty znajdujące się na pierwszym slajdzie.  
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli tak jest.  
- Przejdź przez wszystkie węzły wewnątrz kształtu SmartArt.  
- Uzyskaj dostęp i wyświetl informacje, takie jak pozycja węzła SmartArt, poziom i tekst.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **Dostęp do węzła podrzędnego SmartArt**
Poniższy przykładowy kod pomoże uzyskać dostęp do węzłów podrzędnych należących do poszczególnych węzłów kształtu SmartArt.

- Utwórz instancję klasy PresentationEx i wczytaj prezentację z kształtem SmartArt.  
- Pobierz referencję pierwszego slajdu, używając jego indeksu.  
- Przejdź przez wszystkie kształty znajdujące się na pierwszym slajdzie.  
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArtEx, jeśli tak jest.  
- Przejdź przez wszystkie węzły wewnątrz kształtu SmartArt.  
- Dla każdego wybranego węzła kształtu SmartArt przejdź przez wszystkie węzły podrzędne w danym węźle.  
- Uzyskaj dostęp i wyświetl informacje, takie jak pozycja węzła podrzędnego, poziom i tekst.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **Dostęp do węzła podrzędnego SmartArt w określonej pozycji**
W tym przykładzie nauczymy się uzyskiwać dostęp do węzłów podrzędnych w wybranej pozycji należących do odpowiednich węzłów kształtu SmartArt.

- Utwórz instancję klasy `Presentation`.  
- Pobierz referencję pierwszego slajdu, używając jego indeksu.  
- Dodaj kształt SmartArt typu StackedList.  
- Uzyskaj dostęp do dodanego kształtu SmartArt.  
- Uzyskaj dostęp do węzła o indeksie 0 w wybranym kształcie SmartArt.  
- Następnie uzyskaj dostęp do węzła podrzędnego na pozycji 1 dla wybranego węzła SmartArt, używając metody GetNodeByPosition().  
- Uzyskaj dostęp i wyświetl informacje, takie jak pozycja węzła podrzędnego, poziom i tekst.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **Usuwanie węzła SmartArt**
W tym przykładzie nauczymy się usuwać węzły wewnątrz kształtu SmartArt.

- Utwórz instancję klasy `Presentation` i wczytaj prezentację z kształtem SmartArt.  
- Pobierz referencję pierwszego slajdu, używając jego indeksu.  
- Przejdź przez wszystkie kształty znajdujące się na pierwszym slajdzie.  
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli tak jest.  
- Sprawdź, czy SmartArt ma więcej niż 0 węzłów.  
- Wybierz węzeł SmartArt do usunięcia.  
- Następnie usuń wybrany węzeł, używając metody RemoveNode().  
- Zapisz prezentację.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **Usuwanie węzła SmartArt w określonej pozycji**
W tym przykładzie nauczymy się usuwać węzły wewnątrz kształtu SmartArt w konkretnej pozycji.

- Utwórz instancję klasy `Presentation` i wczytaj prezentację z kształtem SmartArt.  
- Pobierz referencję pierwszego slajdu, używając jego indeksu.  
- Przejdź przez wszystkie kształty znajdujące się na pierwszym slajdzie.  
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli tak jest.  
- Wybierz węzeł kształtu SmartArt o indeksie 0.  
- Sprawdź, czy wybrany węzeł SmartArt ma więcej niż 2 węzły podrzędne.  
- Usuń węzeł na pozycji 1, używając metody RemoveNodeByPosition().  
- Zapisz prezentację.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **Ustawienie niestandardowej pozycji dla węzła podrzędnego SmartArt**
Teraz Aspose.Slides obsługuje ustawianie właściwości X i Y kształtu SmartArt. Poniższy fragment kodu pokazuje, jak ustawić niestandardową pozycję, rozmiar i obrót kształtu SmartArt; należy pamiętać, że dodawanie nowych węzłów powoduje przeliczenie pozycji i rozmiarów wszystkich węzłów.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **Sprawdzanie węzła asystenta**
W poniższym przykładzie sprawdzimy, jak zidentyfikować węzły asystenta w kolekcji węzłów SmartArt i zmienić ich status.

- Utwórz instancję klasy PresentationEx i wczytaj prezentację z kształtem SmartArt.  
- Pobierz referencję drugiego slajdu, używając jego indeksu.  
- Przejdź przez wszystkie kształty znajdujące się na pierwszym slajdzie.  
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArtEx, jeśli tak jest.  
- Przejdź przez wszystkie węzły wewnątrz kształtu SmartArt i sprawdź, czy są to węzły asystenta.  
- Zmień status węzła asystenta na węzeł normalny.  
- Zapisz prezentację.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **Ustawienie formatu wypełnienia węzła**
Aspose.Slides for C++ umożliwia dodawanie własnych kształtów SmartArt i ustawianie ich formatów wypełnienia. Ten artykuł wyjaśnia, jak tworzyć i uzyskiwać dostęp do kształtów SmartArt oraz ustawiać ich format wypełnienia przy użyciu Aspose.Slides for C++.

Proszę wykonać następujące kroki:

- Utwórz instancję klasy `Presentation`.  
- Pobierz referencję slajdu, używając jego indeksu.  
- Dodaj kształt SmartArt, określając jego LayoutType.  
- Ustaw FillFormat dla węzłów kształtu SmartArt.  
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **Generowanie miniaturki węzła podrzędnego SmartArt**
Programiści mogą wygenerować miniaturkę węzła podrzędnego SmartArt, wykonując poniższe kroki:

1. Utwórz instancję klasy `Presentation`, która reprezentuje plik PPTX.  
2. Dodaj SmartArt.  
3. Pobierz referencję węzła, używając jego indeksu.  
4. Uzyskaj obraz miniaturki.  
5. Zapisz miniaturkę w wybranym formacie obrazu.

Poniższy przykład generuje miniaturkę węzła podrzędnego SmartArt

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Czy animacje SmartArt są wspierane?**

Tak. SmartArt jest traktowany jak zwykły kształt, więc można [zastosować standardowe animacje](/slides/pl/cpp/shape-animation/) (wejścia, wyjścia, podkreślenia, ścieżki ruchu) oraz dostosować ich czas. W razie potrzeby można animować także kształty wewnątrz węzłów SmartArt.

**Jak mogę niezawodnie zlokalizować konkretny SmartArt na slajdzie, jeśli jego wewnętrzny identyfikator jest nieznany?**

Użyj i wyszukuj po [alternatywnym tekście]((https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/set_alternativetext/)). Ustawiając charakterystyczny AltText na elemencie SmartArt, można go odnaleźć programowo bez polegania na wewnętrznych identyfikatorach.

**Czy wygląd SmartArt zostanie zachowany przy konwersji prezentacji do PDF?**

Tak. Aspose.Slides renderuje SmartArt z wysoką wiernością wizualną podczas [eksportu do PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/), zachowując układ, kolory i efekty.

**Czy mogę wyodrębnić obraz całego SmartArt (np. do podglądów lub raportów)?**

Tak. Można renderować kształt SmartArt do [formatów rastrowych]((https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/getimage/)) lub do [SVG]((https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/writeassvg/)) dla skalowalnego wyjścia wektorowego, co sprawdza się jako miniaturka, w raporcie lub na stronie internetowej.