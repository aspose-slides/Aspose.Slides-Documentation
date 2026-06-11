---
title: Usprawnij zastąpienie czcionek w prezentacjach przy użyciu Pythona
linktitle: Zastąpienie czcionki
type: docs
weight: 60
url: /pl/python-net/font-replacement/
keywords:
- czcionka
- zastąp czcionkę
- zastąpienie czcionki
- zmiana czcionki
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Bezproblemowo zastąp czcionki w Aspose.Slides Python przez .NET, aby zapewnić spójną typografię w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides pozwala zastąpić jedną czcionkę inną w całej prezentacji. Gdy czcionka zostaje zastąpiona, wszystkie wystąpienia oryginalnej czcionki są zmieniane na nową czcionkę.

Aby wykonać zastąpienie czcionki, wczytaj prezentację, określ czcionkę źródłową i czcionkę zastępczą, wywołaj metodę zastąpienia czcionki i zapisz zmodyfikowaną prezentację jako plik PPTX. To podejście jest przydatne, gdy zamierzasz przełączyć się z jednej rodziny czcionek na inną w całej prezentacji.

## **Zastąp czcionki**

Jeśli zmienisz zdanie co do użycia czcionki, możesz zamienić tę czcionkę na inną. Wszystkie wystąpienia starej czcionki zostaną zastąpione nową czcionką.

Aspose.Slides umożliwia zastąpienie czcionki w następujący sposób:

1. Wczytaj odpowiednią prezentację.  
2. Wczytaj czcionkę, która ma zostać zastąpiona.  
3. Wczytaj nową czcionkę.  
4. Zastąp czcionkę.  
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Pythona demonstruje zastąpienie czcionki:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Ładuje prezentację
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Ładuje czcionkę źródłową, która będzie zastąpiona
    sourceFont = slides.FontData("Arial")

    # Ładuje nową czcionkę
    destFont = slides.FontData("Times New Roman")

    # Zastępuje czcionki
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Zapisuje prezentację
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Uwaga" color="warning" %}} 
Aby ustawić reguły określające, co ma się stać w określonych warunkach (np. gdy czcionka jest niedostępna), zobacz [**Zastąpienie czcionki**](/slides/pl/python-net/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między „zastąpieniem czcionki”, „zastąpieniem czcionki” a „czcionkami awaryjnymi”?**

Zastąpienie to zamierzona zmiana z jednej rodziny na inną w całym dokumencie. [Zastąpienie](/slides/pl/python-net/font-substitution/) to reguła typu „jeśli czcionka jest niedostępna, użyj X”. [Awaryjna](/slides/pl/python-net/fallback-font/) jest stosowana precyzyjnie dla pojedynczych brakujących glifów, gdy podstawowa czcionka jest zainstalowana, ale nie zawiera wymaganych znaków.

**Czy zastąpienie dotyczy slajdów głównych, układów, notatek i komentarzy?**

Tak. Zastąpienie wpływa na wszystkie obiekty prezentacji używające oryginalnej czcionki, w tym slajdy główne i notatki; komentarze są również częścią dokumentu i są brane pod uwagę przez silnik czcionek.

**Czy czcionka zostanie zmieniona w osadzonych obiektach OLE (np. Excel)?**

Nie. [Zawartość OLE](/slides/pl/python-net/manage-ole/) jest kontrolowana przez własną aplikację. Zastąpienie w prezentacji nie reformatuje wewnętrznych danych OLE; może być wyświetlane jako obraz lub jako zewnętrznie edytowalna zawartość.

**Czy mogę zastąpić czcionkę tylko w części prezentacji (wg slajdów lub regionów)?**

Ukierunkowane zastąpienie jest możliwe, jeśli zmienisz czcionkę na poziomie wymaganych obiektów/zakresów, zamiast stosować globalne zastąpienie w całym dokumencie. Ogólna logika wyboru czcionki podczas renderowania pozostaje taka sama.

**Jak mogę z góry określić, jakich czcionek używa prezentacja?**

Użyj [menedżera czcionek](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/): udostępnia listę [rodzin w użyciu](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_fonts/) oraz informacje o [zastąpieniach/„nieznanych” czcionkach](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsmanager/get_substitutions/), co pomaga zaplanować zastąpienie.

**Czy zastąpienie czcionki działa przy konwersji do PDF/obrazów?**

Tak. Podczas eksportu Aspose.Slides stosuje tę samą [sekwencję wyboru/zastąpienia czcionki](/slides/pl/python-net/font-selection-sequence/), więc wcześniej wykonane zastąpienie zostanie uwzględnione przy konwersji.

**Czy muszę zainstalować docelową czcionkę w systemie, czy mogę załączyć folder z czcionkami?**

Instalacja nie jest wymagana: biblioteka umożliwia [ładowanie czcionek zewnętrznych](/slides/pl/python-net/custom-font/) z folderów użytkownika do użycia podczas [renderowania i eksportu](/slides/pl/python-net/convert-powerpoint/).

**Czy zastąpienie naprawi „tofu” (kwadraty) zamiast znaków?**

Tylko jeśli docelowa czcionka rzeczywiście zawiera wymagane glify. Jeśli nie, [skonfiguruj awaryjną](/slides/pl/python-net/fallback-font/) aby pokryć brakujące znaki.