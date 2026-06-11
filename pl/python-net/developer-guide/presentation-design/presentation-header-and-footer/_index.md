---
title: Zarządzanie nagłówkami i stopkami prezentacji w Pythonie
linktitle: Nagłówek i stopka
type: docs
weight: 140
url: /pl/python-net/presentation-header-and-footer/
keywords:
- nagłówek
- tekst nagłówka
- stopka
- tekst stopki
- ustaw nagłówek
- ustaw stopkę
- rozdanie
- notatki
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Użyj Aspose.Slides for Python via .NET, aby dodać i dostosować nagłówki oraz stopki w prezentacjach PowerPoint i OpenDocument, zapewniając profesjonalny wygląd."
---
## **Przegląd**

Aspose.Slides for Python pozwala kontrolować symbole nagłówka i stopki w całej prezentacji z precyzyjnym zakresem. Tekst stopki, data/godzina oraz numery slajdów są zarządzane na poziomie nadrzędnym i mogą być stosowane globalnie lub dostosowywane dla poszczególnych slajdów. Nagłówki są obsługiwane w notatkach i materiałach rozdawniczych, gdzie można przełączać ich widoczność oraz ustawiać tekst nagłówka, stopki, daty/godziny i numerów stron za pomocą dedykowanego menedżera nagłówka i stopki na głównym slajdzie notatek lub pojedynczych slajdów notatek. Ten artykuł opisuje główne wzorce aktualizacji tych symboli i propagowania zmian konsekwentnie w całej prezentacji.

## **Zarządzanie tekstem nagłówka i stopki**

W tej sekcji dowiesz się, jak zarządzać zawartością nagłówka i stopki w prezentacji — włączać lub modyfikować stopkę, datę i godzinę oraz numery slajdów. Krótko przedstawimy zakresy stosowania tych ustawień (cała prezentacja, poszczególne slajdy oraz widoki notatek/rozdania) oraz pokażemy, jak używać API Aspose.Slides do szybkiej i spójnej aktualizacji.

Poniższy przykład kodu otwiera prezentację, włącza i ustawia tekst stopki, aktualizuje tekst nagłówka na głównym slajdzie notatek i zapisuje plik.

```py
import aspose.slides as slides

# Funkcja ustawiająca tekst nagłówka.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Wczytaj prezentację.
with slides.Presentation("sample.pptx") as presentation:
    # Ustaw stopkę.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Uzyskaj dostęp i zaktualizuj nagłówek.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Zapisz prezentację.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Zarządzanie nagłówkiem i stopką na slajdach notatek**

W tej sekcji dowiesz się, jak zarządzać nagłówkami i stopkami konkretnie dla slajdów notatek w Aspose.Slides. Omówimy włączanie odpowiednich symboli, ustawianie tekstu dla stopki, daty/godziny i numerów stron oraz stosowanie tych zmian konsekwentnie w całym masterze notatek oraz poszczególnych stronach notatek.

Postępuj według poniższych kroków:

1. Wczytaj plik prezentacji.  
2. Pobierz slajd notatek nadrzędnych oraz jego [menedżer nagłówka i stopki](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masternotesslideheaderfootermanager/).  
3. Na slajdzie notatek nadrzędnych włącz widoczność Header, Footer, Slide number i Date-time dla mastera i wszystkich podrzędnych slajdów notatek.  
4. Na slajdzie notatek nadrzędnych ustaw tekst dla Header, Footer i Date-time dla mastera i wszystkich podrzędnych slajdów notatek.  
5. Pobierz slajd notatek pierwszego slajdu prezentacji oraz jego [menedżer nagłówka i stopki](https://reference.aspose.com/slides/pl/python-net/aspose.slides/notesslideheaderfootermanager/).  
6. Dla tego pierwszego slajdu notatek upewnij się, że Header, Footer, Slide number i Date-time są widoczne (włącz te, które są wyłączone).  
7. Dla tego pierwszego slajdu notatek ustaw tekst dla Header, Footer i Date-time.  
8. Zapisz prezentację w formacie PPTX.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Ustaw widoczność slajdu notatek głównego oraz wszystkich podrzędnych symboli nagłówka, stopki, numeru slajdu i daty/godziny.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Ustaw tekst na slajdzie notatek głównego oraz wszystkich podrzędnych symbolach nagłówka, stopki i daty/godziny.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Zmień ustawienia nagłówka, stopki, numeru slajdu i daty/godziny tylko dla pierwszego slajdu notatek.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Upewnij się, że symbole nagłówka, stopki, numeru slajdu i daty/godziny są widoczne.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Ustaw tekst w symbolach nagłówka, stopki i daty/godziny slajdu notatek.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Zapisz prezentację.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę dodać „nagłówek” do zwykłych slajdów?**

W programie PowerPoint „Header” istnieje tylko dla notatek i materiałów rozdawniczych; na zwykłych slajdach obsługiwane elementy to stopka, data/godzina i numer slajdu. W Aspose.Slides obowiązuje ta sama ograniczenie: nagłówek tylko dla Notes/Handout, a na slajdach — Footer/DateTime/SlideNumber.

**Co jeśli układ nie zawiera obszaru stopki — czy mogę „włączyć” jej widoczność?**

Tak. Sprawdź widoczność za pomocą menedżera nagłówka i stopki i włącz ją w razie potrzeby. Te wskaźniki i metody API są zaprojektowane z myślą o sytuacjach, gdy symbol jest brakujący lub ukryty.

**Jak ustawić numerację slajdów zaczynającą się od wartości innej niż 1?**

Ustaw [pierwszy numer slajdu](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/first_slide_number/) w prezentacji; po tym wszystkie numery zostaną przeliczone. Na przykład możesz rozpocząć od 0 lub 10 i ukryć numer na slajdzie tytułowym.

**Co się dzieje z nagłówkami/stopkami przy eksporcie do PDF/obrazów/HTML?**

Są renderowane jako zwykłe elementy tekstowe prezentacji. To znaczy, że jeśli elementy są widoczne na slajdach/stronach notatek, pojawią się również w formacie wyjściowym razem z resztą zawartości.