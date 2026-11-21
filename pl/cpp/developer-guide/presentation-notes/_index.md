---
title: Zarządzaj notatkami prezentacji w C++
linktitle: Notatki prezentacji
type: docs
weight: 110
url: /pl/cpp/presentation-notes/
keywords:
- notatki
- slajd z notatkami
- dodaj notatki
- usuń notatki
- styl notatek
- notatki główne
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dostosuj notatki prezentacji za pomocą Aspose.Slides dla C++. Bezproblemowo pracuj z notatkami PowerPoint i OpenDocument, aby zwiększyć swoją wydajność."
---
## **Przegląd**

Aspose.Slides obsługuje usuwanie slajdów z notatkami z prezentacji. W tym temacie przedstawimy tę funkcję, w tym jak usuwać notatki oraz jak zastosować styl do slajdów z notatkami w prezentacji. Aspose.Slides umożliwia usunięcie notatek z dowolnego slajdu oraz zastosowanie formatowania do istniejących notatek. Programiści mogą usuwać notatki w następujący sposób:

- Usuń notatki z konkretnego slajdu w prezentacji.
- Usuń notatki ze wszystkich slajdów w prezentacji.

Aby odczytać lub zmienić wymiary strony z notatkami, zmienić orientację i sprawdzić zachowanie eksportu, zobacz [Rozmiar strony z notatkami](/slides/pl/cpp/notes-size/).

## **Usuń notatki z konkretnego slajdu**
Notatki z konkretnego slajdu można usunąć, jak przedstawiono w przykładzie poniżej:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Usuń notatki ze wszystkich slajdów**
Notatki ze wszystkich slajdów w prezentacji można usunąć, jak przedstawiono w przykładzie poniżej:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Dodaj styl notatek**
Właściwość NotesStyle została dodana do interfejsu IMasterNotesSlide oraz klasy MasterNotesSlide. Ta właściwość określa styl tekstu notatek. Implementacja jest pokazana w poniższym przykładzie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

### Który podmiot API zapewnia dostęp do notatek konkretnego slajdu?
Do notatek można uzyskać poprzez menedżera notatek slajdu: slajd posiada [NotesSlideManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/notesslidemanager/) i [metodę](https://reference.aspose.com/slides/pl/cpp/aspose.slides/notesslidemanager/get_notesslide/), która zwraca obiekt notatek, lub `null`, jeśli notatek nie ma.

### Czy istnieją różnice w obsłudze notatek w różnych wersjach PowerPoint, z którymi współpracuje biblioteka?
Biblioteka obsługuje szeroki zakres formatów Microsoft PowerPoint (97-nowsze) oraz ODP; notatki są wspierane w tych formatach bez konieczności posiadania zainstalowanej wersji PowerPoint.