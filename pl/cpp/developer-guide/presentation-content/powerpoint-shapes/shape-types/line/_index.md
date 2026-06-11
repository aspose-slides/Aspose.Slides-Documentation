---
title: Dodaj kształty linii do prezentacji w C++
linktitle: Linia
type: docs
weight: 50
url: /pl/cpp/line/
keywords:
- linia
- tworzenie linii
- dodawanie linii
- prosta linia
- konfiguracja linii
- dostosowanie linii
- styl kreski
- grot strzałki
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak manipulować formatowaniem linii w prezentacjach PowerPoint za pomocą Aspose.Slides dla C++. Odkryj właściwości, metody i przykłady."
---
## **Przegląd**

Aspose.Slides pozwala programowo dodawać kształty linii do slajdów PowerPoint. Ten artykuł pokazuje, jak utworzyć prostą linię i jak dostosować linię, aby wyglądała jak strzałka.

Nauczysz się, jak dodać kształt linii do slajdu, dostosować jej wygląd oraz zapisać zaktualizowaną prezentację. Przykłady koncentrują się na praktycznych ustawieniach formatowania linii, takich jak styl, szerokość, wzór kreski, opcje grotu strzałki oraz kolor wypełnienia.

## **Utwórz prostą linię**
Aby dodać prostą linię do wybranego slajdu prezentacji, postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation class](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Linia, używając metody [AddAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/addautoshape/), udostępnionej przez obiekt Shapes.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy linię do pierwszego slajdu prezentacji.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **Utwórz linię w kształcie strzałki**
Aspose.Slides for C++ umożliwia również programistom konfigurowanie niektórych właściwości linii, aby wyglądała atrakcyjniej. Spróbujmy skonfigurować kilka właściwości linii, aby wyglądała jak strzałka. Postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation class](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Linia, używając metody AddAutoShape udostępnionej przez obiekt Shapes.
- Ustaw styl linii na jeden ze stylów oferowanych przez Aspose.Slides for C++.
- Ustaw szerokość linii.
- Ustaw [Dash Style](https://reference.aspose.com/slides/pl/cpp/aspose.slides/linedashstyle/) linii na jeden ze stylów oferowanych przez Aspose.Slides for C++.
- Ustaw [Arrow Head Style](https://reference.aspose.com/slides/pl/cpp/aspose.slides/lineformat/) i długość punktu początkowego linii.
- Ustaw styl grotu strzałki i długość punktu końcowego linii.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **FAQ**

**Czy mogę zamienić zwykłą linię w łącznik, aby „przyczepiała się” do kształtów?**

Nie. Zwykła linia ([AutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/autoshape/) typu [Line](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shapetype/)) nie zamienia się automatycznie w łącznik. Aby przyczepić ją do kształtów, użyj dedykowanego typu [Connector](https://reference.aspose.com/slides/pl/cpp/aspose.slides/connector/) oraz [odpowiednich interfejsów API](/slides/pl/cpp/connector/) do połączeń.

**Co zrobić, gdy właściwości linii są dziedziczone z motywu i trudno określić ich ostateczne wartości?**

[Przeczytaj właściwości efektywne](/slides/pl/cpp/shape-effective-properties/) za pośrednictwem interfejsów [ILineFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilinefillformateffectivedata/) — uwzględniają one już dziedziczenie i style motywu.

**Czy mogę zablokować linię przed edycją (przemieszczaniem, zmianą rozmiaru)?**

Tak. Kształty udostępniają [obiekty blokady](https://reference.aspose.com/slides/pl/cpp/aspose.slides/autoshape/get_autoshapelock/), które pozwalają [zakazać operacji edycyjnych](/slides/pl/cpp/applying-protection-to-presentation/).