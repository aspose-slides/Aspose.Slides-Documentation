---
title: Z​arządzaj notatkami prezentacji w C++
linktitle: Notatki prezentacji
type: docs
weight: 110
url: /pl/cpp/presentation-notes/
keywords:
- notatki
- slajd notatek
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

Aspose.Slides obsługuje usuwanie slajdów z notatkami z prezentacji. W tym temacie przedstawimy tę funkcję, w tym jak usuwać notatki oraz jak zastosować styl do slajdów z notatkami w prezentacji. Aspose.Slides umożliwia usunięcie notatek z dowolnego slajdu oraz zastosowanie stylizacji do istniejących notatek. Programiści mogą usuwać notatki w następujący sposób:

- Usuń notatki z konkretnego slajdu w prezentacji.
- Usuń notatki ze wszystkich slajdów w prezentacji.

## **Usuń notatki z konkretnego slajdu**
Notatki wybranego slajdu można usunąć, jak pokazano w poniższym przykładzie:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **Usuń notatki ze wszystkich slajdów**
Notatki ze wszystkich slajdów prezentacji można usunąć, jak pokazano w poniższym przykładzie:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **Dodaj styl notatek**
W interfejsie IMasterNotesSlide oraz klasie MasterNotesSlide została dodana własność NotesStyle. Określa ona styl tekstu notatek. Implementacja została przedstawiona w poniższym przykładzie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

**Który element API zapewnia dostęp do notatek konkretnego slajdu?**

Notatki są dostępne poprzez menedżera notatek slajdu: slajd posiada [NotesSlideManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/notesslidemanager/) oraz [metodę](https://reference.aspose.com/slides/pl/cpp/aspose.slides/notesslidemanager/get_notesslide/), która zwraca obiekt notatek lub `null`, jeśli notatek nie ma.

**Czy istnieją różnice w obsłudze notatek w różnych wersjach PowerPoint, z którymi biblioteka współpracuje?**

Biblioteka obsługuje szeroki zakres formatów Microsoft PowerPoint (od wersji 97 do najnowszych) oraz ODP; notatki są wspierane w tych formatach bez konieczności posiadania zainstalowanej kopii programu PowerPoint.