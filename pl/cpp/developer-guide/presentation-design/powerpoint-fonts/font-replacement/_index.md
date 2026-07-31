---
title: Usprawnij zamianę czcionek w prezentacjach przy użyciu C++
linktitle: Zastąpienie czcionki
type: docs
weight: 60
url: /pl/cpp/font-replacement/
keywords:
- czcionka
- zastąp czcionkę
- zastąpienie czcionki
- zmień czcionkę
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Bezproblemowo zastąp czcionki w Aspose.Slides dla C++, aby zapewnić spójną typografię w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia zastąpienie jednej czcionki inną w całej prezentacji. Gdy czcionka zostaje zastąpiona, wszystkie wystąpienia oryginalnej czcionki są zmieniane na nową czcionkę.

Aby wykonać zamianę czcionki, wczytaj prezentację, określ czcionkę źródłową i czcionkę zastępczą, wywołaj metodę zamiany czcionki i zapisz zmodyfikowaną prezentację jako plik PPTX. To podejście jest przydatne, gdy zamierzenie chcesz przełączyć jedną rodzinę czcionek na inną w całej prezentacji.

## **Zastąp czcionki**

Jeśli zmienisz zdanie odnośnie używania czcionki, możesz zastąpić tę czcionkę inną. Wszystkie wystąpienia starej czcionki zostaną zastąpione nową czcionką. 

Aspose.Slides umożliwia zamianę czcionki w następujący sposób:

1. Wczytaj odpowiednią prezentację. 
2. Wczytaj czcionkę, która ma zostać zastąpiona.
3. Wczytaj nową czcionkę. 
4. Zastąp czcionkę. 
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod C++ demonstruje zamianę czcionki:

``` cpp
// Ładuje prezentację
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Ładuje czcionkę źródłową, która ma zostać zastąpiona
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Ładuje nową czcionkę
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Zastępuje czcionki
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Zapisuje prezentację
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Aby ustawić reguły określające, co się stanie w określonych warunkach (np. gdy czcionka nie jest dostępna), zobacz [**Substitucja czcionki**](/slides/pl/cpp/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między „zastąpieniem czcionki”, „substitucją czcionki” i „czcionkami zapasowymi”?**

Zastąpienie to zamierzone przełączenie jednej rodziny na inną w całym dokumencie. [Substitucja](/slides/pl/cpp/font-substitution/) to reguła typu „jeśli czcionka jest niedostępna, użyj X”. [Zapasowa](/slides/pl/cpp/fallback-font/) jest stosowana precyzyjnie dla pojedynczych brakujących glifów, gdy podstawowa czcionka jest zainstalowana, ale nie zawiera wymaganych znaków.

**Czy zastąpienie dotyczy slajdów głównych, układów, notatek i komentarzy?**

Tak. Zastąpienie wpływa na wszystkie obiekty prezentacji używające oryginalnej czcionki, w tym slajdy główne i notatki; komentarze również są częścią dokumentu i są brane pod uwagę przez silnik czcionek.

**Czy czcionka zmieni się w osadzonych obiektach OLE (np. Excel)?**

Nie. [Zawartość OLE](/slides/pl/cpp/manage-ole/) jest kontrolowana przez własną aplikację. Zastąpienie w prezentacji nie przekształca wewnętrznych danych OLE; mogą być wyświetlane jako obraz lub jako edytowalna zewnętrznie zawartość.

**Czy mogę zastąpić czcionkę tylko w części prezentacji (według slajdów lub regionów)?**

Zastąpienie skierowane jest możliwe, jeśli zmienisz czcionkę na poziomie wymaganych obiektów/zakresów zamiast stosować globalne zastąpienie w całym dokumencie. Ogólna logika wyboru czcionki podczas renderowania pozostaje niezmienna.

**Jak mogę z góry określić, jakich czcionek używa prezentacja?**

Użyj [menedżera czcionek] prezentacji (https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/): dostarcza listę [używanych rodzin](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/getfonts/) oraz informacje o [substitucjach/"nieznanych" czcionkach](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/getsubstitutions/), co pomaga w planowaniu zastąpienia.

**Czy zastąpienie czcionki działa przy konwertowaniu do PDF/obrazów?**

Tak. Podczas eksportu Aspose.Slides stosuje tę samą [sekwencję wyboru/substitucji czcionek](/slides/pl/cpp/font-selection-sequence/), więc wcześniej wykonane zastąpienie zostanie uwzględnione podczas konwersji.

**Czy muszę zainstalować docelową czcionkę w systemie, czy mogę dołączyć folder czcionek?**

Instalacja nie jest wymagana: biblioteka umożliwia [wczytywanie zewnętrznych czcionek](/slides/pl/cpp/custom-font/) z folderów użytkownika do użycia podczas [renderowania i eksportu](/slides/pl/cpp/convert-powerpoint/).

**Czy zastąpienie naprawi „tofu” (kwadraty) zamiast znaków?**

Tylko jeśli docelowa czcionka rzeczywiście zawiera wymagane glify. Jeśli nie, [skonfiguruj czcionkę zapasową](/slides/pl/cpp/fallback-font/), aby pokryć brakujące znaki.