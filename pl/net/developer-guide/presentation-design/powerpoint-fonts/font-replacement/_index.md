---
title: Usprawnij zastępowanie czcionek w prezentacjach w .NET
linktitle: Zastępowanie czcionek
type: docs
weight: 60
url: /pl/net/font-replacement/
keywords:
- czcionka
- zastąp czcionkę
- zastępowanie czcionek
- zmień czcionkę
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Bezproblemowo zastąp czcionki w Aspose.Slides dla .NET, aby zapewnić spójną typografię w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia zastąpienie jednej czcionki inną w całej prezentacji. Gdy czcionka zostaje zastąpiona, wszystkie wystąpienia pierwotnej czcionki są zmieniane na nową czcionkę.

Aby wykonać zastąpienie czcionki, wczytaj prezentację, określ czcionkę źródłową i czcionkę zastępującą, wywołaj metodę zastąpienia czcionki i zapisz zmodyfikowaną prezentację jako plik PPTX. Takie podejście jest przydatne, gdy zamierzasz zamienić jedną rodzinę czcionek na inną w całej prezentacji.

## **Zastępowanie czcionek**

Jeśli zmienisz zdanie co do używania czcionki, możesz zastąpić tę czcionkę inną. Wszystkie wystąpienia starej czcionki zostaną zastąpione nową czcionką.

Aspose.Slides umożliwia zastąpienie czcionki w następujący sposób:

1. Wczytaj odpowiednią prezentację. 
2. Wczytaj czcionkę, która ma zostać zastąpiona.
3. Wczytaj nową czcionkę. 
4. Zastąp czcionkę. 
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C# demonstruje zastąpienie czcionki:

```c#
// Ładuje prezentację
Presentation presentation = new Presentation("Fonts.pptx");

// Ładuje czcionkę źródłową, która ma zostać zastąpiona
IFontData sourceFont = new FontData("Arial");

// Ładuje nową czcionkę
IFontData destFont = new FontData("Times New Roman");

// Zastępuje czcionki
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Zapisuje prezentację
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="Note" color="warning" %}} 
Aby ustawić reguły określające, co się dzieje w określonych warunkach (np. gdy czcionka nie jest dostępna), zobacz [**Zastępowanie czcionek**](/slides/pl/net/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między „zastąpieniem czcionki”, „zastąpieniem czcionki” a „czcionkami zastępczymi”?**

Zastąpienie to zamierzona zmiana jednej rodziny czcionek na inną w całym dokumencie. [Zastąpienie](/slides/pl/net/font-substitution/) to zasada typu „jeśli czcionka jest niedostępna, użyj X”. [Czcionki zastępcze](/slides/pl/net/fallback-font/) są stosowane precyzyjnie dla pojedynczych brakujących glifów, gdy podstawowa czcionka jest zainstalowana, ale nie zawiera wymaganych znaków.

**Czy zastąpienie dotyczy slajdów master, układów, notatek i komentarzy?**

Tak. Zastąpienie wpływa na wszystkie obiekty prezentacji używające pierwotnej czcionki, w tym slajdy master i notatki; komentarze również są częścią dokumentu i są uwzględniane przez silnik czcionek.

**Czy czcionka zmieni się w osadzonych obiektach OLE (np. Excel)?**

Nie. [Zawartość OLE](/slides/pl/net/manage-ole/) jest kontrolowana przez własną aplikację. Zastąpienie w prezentacji nie reformatuje wewnętrznych danych OLE; mogą być wyświetlane jako obraz lub jako edytowalna zawartość zewnętrzna.

**Czy mogę zastąpić czcionkę tylko w części prezentacji (na slajdach lub regionach)?**

Ukierunkowane zastąpienie jest możliwe, jeśli zmienisz czcionkę na poziomie wymaganych obiektów/zakresów, a nie stosujesz globalnego zastąpienia w całym dokumencie. Logika wyboru czcionki podczas renderowania pozostaje taka sama.

**Jak mogę z góry określić, jakich czcionek używa prezentacja?**

Użyj [menedżera czcionek](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/): udostępnia listę [używanych rodzin](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/getfonts/) oraz informacje o [zastąpieniach/„nieznane” czcionki](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/getsubstitutions/), co pomaga zaplanować zastąpienie.

**Czy zastąpienie czcionki działa przy konwersji do PDF/obrazów?**

Tak. Podczas eksportu Aspose.Slides stosuje tę samą [sekwencję wyboru/zastępowania czcionek](/slides/pl/net/font-selection-sequence/), więc wcześniej wykonane zastąpienie zostanie uwzględnione podczas konwersji.

**Czy muszę zainstalować docelową czcionkę w systemie, czy mogę dołączyć folder czcionek?**

Instalacja nie jest wymagana: biblioteka umożliwia [ładowanie zewnętrznych czcionek](/slides/pl/net/custom-font/) z folderów użytkownika do użycia podczas [renderowania i eksportu](/slides/pl/net/convert-powerpoint/).

**Czy zastąpienie naprawi problem „tofu” (kwadraty) zamiast znaków?**

Tylko jeśli docelowa czcionka rzeczywiście zawiera wymagane glify. Jeśli nie, [skonfiguruj czcionki zastępcze](/slides/pl/net/fallback-font/), aby pokryć brakujące znaki.