---
title: Zarządzaj węzłami kształtu SmartArt w prezentacjach przy użyciu Pythona
linktitle: Węzeł kształtu SmartArt
type: docs
weight: 30
url: /pl/python-net/manage-smartart-shape-node/
keywords:
- węzeł SmartArt
- węzeł potomny
- dodaj węzeł
- pozycja węzła
- dostęp do węzła
- usuń węzeł
- niestandardowa pozycja
- węzeł asystenta
- format wypełnienia
- renderowanie węzła
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj węzłami kształtu SmartArt w plikach PPT, PPTX i ODP przy użyciu Aspose.Slides for Python via .NET. Uzyskaj przejrzyste przykłady kodu i wskazówki, aby usprawnić swoje prezentacje."
---
## **Przegląd**

Grafiki SmartArt w prezentacjach PowerPoint są organizowane za pomocą węzłów zawierających tekst i definiujących strukturę diagramu. Aspose.Slides umożliwia programowe pracowanie z tymi węzłami SmartArt: dodawanie nowych węzłów i węzłów potomnych, wstawianie węzłów potomnych w określonej pozycji, dostęp do istniejących węzłów oraz odczytywanie ich tekstu, poziomu i pozycji.

Ten artykuł wyjaśnia, jak zarządzać węzłami kształtu SmartArt. Pokazuje, jak usuwać węzły, pracować z węzłami potomnymi według indeksu lub pozycji, zmienić węzeł pomocniczy na zwykły, dostosować pozycję, rozmiar i obrót kształtów węzłów SmartArt, ustawić formaty wypełnienia węzła oraz wygenerować miniaturę obrazu dla węzła potomnego SmartArt.

## **Dodaj węzeł SmartArt**
Aspose.Slides for Python via .NET udostępnia najprostsze API do zarządzania kształtami SmartArt w najłatwiejszy sposób. Poniższy przykładowy kod pomoże dodać węzeł i węzeł potomny wewnątrz kształtu SmartArt.

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i załaduj prezentację z kształtem SmartArt.
- Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
- Przejdź po wszystkich kształtach wewnątrz pierwszego slajdu.
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli jest SmartArt.
- Dodaj nowy węzeł do kolekcji NodeCollection kształtu SmartArt i ustaw tekst w TextFrame.
- Następnie dodaj węzeł potomny do nowo dodanego węzła SmartArt i ustaw tekst w TextFrame.
- Zapisz prezentację.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Wczytaj żądaną prezentację
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Przejdź przez wszystkie kształty na pierwszym slajdzie
    for shape in pres.slides[0].shapes:

        # Sprawdź, czy kształt jest typu SmartArt
        if type(shape) is art.SmartArt:
            # Dodawanie nowego węzła SmartArt
            node1 = shape.all_nodes.add_node()
            # Dodawanie tekstu
            node1.text_frame.text = "Test"

            # Dodawanie nowego węzła potomnego w węźle nadrzędnym. Zostanie on dodany na koniec kolekcji
            new_node = node1.child_nodes.add_node()

            # Dodawanie tekstu
            new_node.text_frame.text = "New Node Added"

    # Zapisywanie prezentacji
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodaj węzeł SmartArt w określonej pozycji**
W poniższym przykładowym kodzie wyjaśniono, jak dodać węzły potomne należące do odpowiednich węzłów kształtu SmartArt w określonej pozycji.

- Utwórz instancję klasy `Presentation`.
- Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
- Dodaj kształt SmartArt typu StackedList na wybranym slajdzie.
- Uzyskaj dostęp do pierwszego węzła w dodanym kształcie SmartArt.
- Następnie dodaj węzeł potomny do wybranego węzła na pozycji 2 i ustaw jego tekst.
- Zapisz prezentację.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Tworzenie instancji prezentacji
with slides.Presentation() as pres:
    # Dostęp do slajdu prezentacji
    slide = pres.slides[0]

    # Dodaj Smart Art IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Uzyskiwanie węzła SmartArt o indeksie 0
    node = smart.all_nodes[0]

    # Dodawanie nowego węzła potomnego na pozycji 2 w węźle nadrzędnym
    chNode = node.child_nodes.add_node_by_position(2)

    # Dodaj tekst
    chNode.text_frame.text = "Sample text Added"

    # Zapisz prezentację
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Dostęp do węzła SmartArt**
Poniższy przykładowy kod pomoże uzyskać dostęp do węzłów wewnątrz kształtu SmartArt. Należy pamiętać, że nie można zmienić LayoutType SmartArt, ponieważ jest on tylko do odczytu i jest ustawiany jedynie podczas dodawania kształtu SmartArt.

- Utwórz instancję klasy `Presentation` i załaduj prezentację z kształtem SmartArt.
- Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
- Przejdź po wszystkich kształtach wewnątrz pierwszego slajdu.
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli jest SmartArt.
- Przejdź po wszystkich węzłach wewnątrz kształtu SmartArt.
- Uzyskaj dostęp i wyświetl informacje, takie jak pozycja węzła SmartArt, poziom i tekst.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Wczytaj żądaną prezentację
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Przejdź przez wszystkie kształty na pierwszym slajdzie
    for shape in pres.slides[0].shapes:
        # Sprawdź, czy kształt jest typu SmartArt
        if type(shape) is art.SmartArt:
            # Przejdź przez wszystkie węzły wewnątrz SmartArt
            for i in range(len(shape.all_nodes)):
                # Uzyskiwanie węzła SmartArt o indeksie i
                node = shape.all_nodes[i]

                # Wyświetlanie parametrów węzła SmartArt
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```

## **Dostęp do węzła potomnego SmartArt**
Poniższy przykładowy kod pomoże uzyskać dostęp do węzłów potomnych należących do odpowiednich węzłów kształtu SmartArt.

- Utwórz instancję klasy PresentationEx i załaduj prezentację z kształtem SmartArt.
- Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
- Przejdź po wszystkich kształtach wewnątrz pierwszego slajdu.
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArtEx, jeśli jest SmartArt.
- Przejdź po wszystkich węzłach wewnątrz kształtu SmartArt.
- Dla każdego wybranego węzła kształtu SmartArt przejdź po wszystkich węzłach potomnych wewnątrz konkretnego węzła.
- Uzyskaj dostęp i wyświetl informacje, takie jak pozycja węzła potomnego, poziom i tekst.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Wczytaj żądaną prezentację
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Przejdź przez wszystkie kształty na pierwszym slajdzie
    for shape in pres.slides[0].shapes:
        # Sprawdź, czy kształt jest typu SmartArt
        if type(shape) is art.SmartArt:
            # Przejdź przez wszystkie węzły wewnątrz SmartArt
            for node0 in shape.all_nodes:
                # Przeglądanie węzłów potomnych
                for j in range(len(node0.child_nodes)):
                    # Uzyskiwanie dostępu do węzła potomnego w węźle SmartArt
                    node = node0.child_nodes[j]

                    # Wyświetlanie parametrów węzła potomnego SmartArt
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))

```

## **Dostęp do węzła potomnego SmartArt w określonej pozycji**
W tym przykładzie nauczymy się uzyskiwać dostęp do węzłów potomnych w określonej pozycji należących do odpowiednich węzłów kształtu SmartArt.

- Utwórz instancję klasy `Presentation`.
- Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
- Dodaj kształt SmartArt typu StackedList.
- Uzyskaj dostęp do dodanego kształtu SmartArt.
- Uzyskaj dostęp do węzła o indeksie 0 w wybranym kształcie SmartArt.
- Następnie uzyskaj dostęp do węzła potomnego na pozycji 1 dla wybranego węzła SmartArt, używając metody GetNodeByPosition().
- Uzyskaj dostęp i wyświetl informacje, takie jak pozycja węzła potomnego, poziom i tekst.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Utwórz instancję prezentacji
with slides.Presentation() as pres:
    # Dostęp do pierwszego slajdu
    slide = pres.slides[0]
    # Dodawanie kształtu SmartArt na pierwszym slajdzie
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Dostęp do węzła SmartArt o indeksie 0
    node = smart.all_nodes[0]
    # Dostęp do węzła potomnego na pozycji 1 w węźle nadrzędnym
    position = 1
    chNode = node.child_nodes[position] 
    # Wyświetlanie parametrów węzła potomnego SmartArt
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```

## **Usuń węzeł SmartArt**
W tym przykładzie nauczymy się usuwać węzły wewnątrz kształtu SmartArt.

- Utwórz instancję klasy `Presentation` i załaduj prezentację z kształtem SmartArt.
- Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
- Przejdź po wszystkich kształtach wewnątrz pierwszego slajdu.
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli jest SmartArt.
- Sprawdź, czy SmartArt ma więcej niż 0 węzłów.
- Wybierz węzeł SmartArt, który ma zostać usunięty.
- Teraz usuń wybrany węzeł przy użyciu metody RemoveNode() i zapisz prezentację.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Wczytaj żądaną prezentację
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Przejdź przez wszystkie kształty na pierwszym slajdzie
    for shape in pres.slides[0].shapes:
        # Sprawdź, czy kształt jest typu SmartArt
        if type(shape) is art.SmartArt:
            # Rzutuj kształt na SmartArtEx
            if len(shape.all_nodes) > 0:
                # Dostęp do węzła SmartArt o indeksie 0
                node = shape.all_nodes[0]

                # Usuwanie wybranego węzła
                shape.all_nodes.remove_node(node)

    # Zapisz prezentację
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Usuń węzeł SmartArt w określonej pozycji**
W tym przykładzie nauczymy się usuwać węzły wewnątrz kształtu SmartArt w określonej pozycji.

- Utwórz instancję klasy `Presentation` i załaduj prezentację z kształtem SmartArt.
- Uzyskaj referencję do pierwszego slajdu, używając jego indeksu.
- Przejdź po wszystkich kształtach wewnątrz pierwszego slajdu.
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli jest SmartArt.
- Wybierz węzeł kształtu SmartArt o indeksie 0.
- Następnie sprawdź, czy wybrany węzeł SmartArt ma więcej niż 2 węzły potomne.
- Teraz usuń węzeł na pozycji 1 przy użyciu metody RemoveNodeByPosition().
- Zapisz prezentację.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Wczytaj żądaną prezentację
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Przejdź przez wszystkie kształty na pierwszym slajdzie
    for shape in pres.slides[0].shapes:
        # Sprawdź, czy kształt jest typu SmartArt
        if type(shape) is art.SmartArt:
            # Rzutuj kształt na SmartArt
            if len(shape.all_nodes) > 0:
                # Dostęp do węzła SmartArt o indeksie 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Usuwanie węzła potomnego na pozycji 1
                    node.child_nodes.remove_node(1)

    # Zapisz prezentację
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw niestandardową pozycję dla węzła potomnego w SmartArt**
Teraz Aspose.Slides for Python via .NET obsługuje ustawianie właściwości X i Y SmartArtShape. Poniższy fragment kodu pokazuje, jak ustawić niestandardową pozycję, rozmiar i obrót SmartArtShape; proszę również zauważyć, że dodawanie nowych węzłów powoduje przeliczenie pozycji i rozmiarów wszystkich węzłów.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Wczytaj żądaną prezentację
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# Przesuń kształt SmartArt na nową pozycję
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# Zmień szerokości kształtu SmartArt
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# Zmień wysokość kształtu SmartArt
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# Zmień obrót kształtu SmartArt
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```

## **Sprawdź węzeł asystenta**
W poniższym przykładowym kodzie zbadamy, jak zidentyfikować węzły asystenta w kolekcji węzłów SmartArt i je zmienić.

- Utwórz instancję klasy PresentationEx i załaduj prezentację z kształtem SmartArt.
- Uzyskaj referencję do drugiego slajdu, używając jego indeksu.
- Przejdź po wszystkich kształtach wewnątrz pierwszego slajdu.
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArtEx, jeśli jest SmartArt.
- Przejdź po wszystkich węzłach wewnątrz kształtu SmartArt i sprawdź, czy są to węzły asystenta.
- Zmień status węzła asystenta na węzeł normalny.
- Zapisz prezentację.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Tworzenie instancji prezentacji
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Przejdź przez wszystkie kształty na pierwszym slajdzie
    for shape in pres.slides[0].shapes:
        # Sprawdź, czy kształt jest typu SmartArt
        if type(shape) is art.SmartArt:
            # Przeglądanie wszystkich węzłów kształtu SmartArt
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Sprawdź, czy węzeł jest węzłem asystenta
                if node.is_assistant:
                    # Ustawienie węzła asystenta na false i zamiana go na węzeł normalny
                    node.is_assistant = False
    # Zapisz prezentację
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw format wypełnienia węzła**
Aspose.Slides for Python via .NET umożliwia dodawanie niestandardowych kształtów SmartArt i ustawianie ich formatów wypełnienia. Ten artykuł wyjaśnia, jak tworzyć i uzyskiwać dostęp do kształtów SmartArt oraz ustawiać ich format wypełnienia przy użyciu Aspose.Slides for Python via .NET.

Proszę wykonać poniższe kroki:

- Utwórz instancję klasy `Presentation`.
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj kształt SmartArt, ustawiając jego LayoutType.
- Ustaw FillFormat dla węzłów kształtu SmartArt.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Dostęp do slajdu
    slide = presentation.slides[0]

    # Dodawanie kształtu SmartArt i węzłów
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # Ustawianie koloru wypełnienia węzła
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Zapisanie prezentacji
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Wygeneruj miniaturę węzła potomnego SmartArt**
Programiści mogą wygenerować miniaturę węzła potomnego SmartArt, wykonując poniższe kroki:

1. Utwórz instancję klasy `Presentation`, która reprezentuje plik PPTX.
2. Dodaj SmartArt.
3. Uzyskaj referencję do węzła, używając jego indeksu
4. Pobierz obraz miniatury.
5. Zapisz obraz miniatury w dowolnym żądanym formacie obrazu.

Poniższy przykład generuje miniaturę węzła potomnego SmartArt

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Utwórz klasę Presentation reprezentującą plik PPTX
with slides.Presentation() as presentation: 
    # Dodaj SmartArt
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Uzyskaj referencję do węzła używając jego indeksu
    node = smart.nodes[1]

    # Pobierz miniaturę
    with node.shapes[0].get_image() as bmp:
        # Zapisz miniaturę
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```

## **FAQ**

**Czy animacja SmartArt jest obsługiwana?**

Tak. SmartArt jest traktowany jak zwykły kształt, więc możesz [zastosować standardowe animacje](/slides/pl/python-net/shape-animation/) (wejścia, wychodzenia, podkreślenia, ścieżki ruchu) i dostosować timing. Możesz również animować kształty wewnątrz węzłów SmartArt w razie potrzeby.

**Jak mogę wiarygodnie zlokalizować konkretny SmartArt na slajdzie, jeśli jego wewnętrzny identyfikator jest nieznany?**

Przypisz i wyszukuj po [alternatywnym tekście](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartart/alternative_text/). Ustawienie charakterystycznego AltText w SmartArt pozwala znaleźć go programowo, nie polegając na wewnętrznych identyfikatorach.

**Czy wygląd SmartArt zostanie zachowany przy konwersji prezentacji do PDF?**

Tak. Aspose.Slides renderuje SmartArt z wysoką wiernością wizualną podczas [eksportu do PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/), zachowując układ, kolory i efekty.

**Czy mogę wyodrębnić obraz całego SmartArt (do podglądów lub raportów)?**

Tak. Możesz renderować kształt SmartArt do [formatów rastrowych](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartart/get_image/) lub do [SVG](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartart/write_as_svg/) jako wyjścia wektorowego, co czyni go odpowiednim do miniatur, raportów lub użycia w sieci.