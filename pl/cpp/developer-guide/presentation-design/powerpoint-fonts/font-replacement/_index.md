---
title: Usprawnij zamianę czcionek w prezentacjach przy użyciu С++
linktitle: Zamiana czcionek
type: docs
weight: 60
url: /pl/cpp/font-replacement/
keywords:
- czcionka
- zastąp czcionkę
- zamiana czcionek
- zmiana czcionki
- PowerPoint
- OpenDocument
- prezentacja
- С++
- Aspose.Slides
description: "Bezproblemowo zamieniaj czcionki w Aspose.Slides dla С++, aby zapewnić spójną typografię w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides pozwala zamienić jedną czcionkę na inną w całej prezentacji. Gdy czcionka zostanie zamieniona, wszystkie wystąpienia oryginalnej czcionki są zmieniane na nową czcionkę.

Aby wykonać zamianę czcionek, wczytaj prezentację, określ czcionkę źródłową i czcionkę zastępczą, wywołaj metodę zamiany czcionek i zapisz zmodyfikowaną prezentację jako plik PPTX. To podejście jest przydatne, gdy celowo chcesz przełączyć się z jednej rodziny czcionek na inną w całej prezentacji.

## **Zamiana czcionek**

Jeśli zmienisz zdanie co do używania czcionki, możesz zamienić tę czcionkę na inną. Wszystkie wystąpienia starej czcionki zostaną zastąpione nową czcionką.

Aspose.Slides pozwala na zamianę czcionki w następujący sposób:

1. Wczytaj odpowiednią prezentację.  
2. Wczytaj czcionkę, która ma zostać zastąpiona.  
3. Wczytaj nową czcionkę.  
4. Zastąp czcionkę.  
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

``` cpp
// Wczytuje prezentację
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Wczytuje czcionkę źródłową, która zostanie zastąpiona
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Wczytuje nową czcionkę
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Zastępuje czcionki
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Zapisuje prezentację
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}}Aby ustawić reguły określające, co się stanie w określonych warunkach (np. gdy czcionka jest niedostępna), zobacz [**Zastąpienie czcionek**](/slides/pl/cpp/font-substitution/).{{% /alert %}}

## **FAQ**

**Jaka jest różnica między „zamianą czcionek”, „zastąpieniem czcionek” a „czcionkami awaryjnymi”?**  
Zamiana to celowe przełączenie z jednej rodziny na inną w całym dokumencie. [Zastąpienie](/slides/pl/cpp/font-substitution/) to reguła typu „jeśli czcionka jest niedostępna, użyj X”. [Czcionki awaryjne](/slides/pl/cpp/fallback-font/) są stosowane precyzyjnie dla pojedynczych brakujących glifów, gdy podstawowa czcionka jest zainstalowana, ale nie zawiera wymaganego znaku.

**Czy zamiana ma zastosowanie do slajdów master, układów, notatek i komentarzy?**  
Tak. Zamiana wpływa na wszystkie obiekty prezentacji używające oryginalnej czcionki, w tym slajdy master i notatki; komentarze są również częścią dokumentu i są brane pod uwagę przez silnik czcionek.

**Czy czcionka zmieni się we wbudowanych obiektach OLE (np. Excel)?**  
Nie. [Zawartość OLE](/slides/pl/cpp/manage-ole/) jest kontrolowana przez własną aplikację. Zamiana w prezentacji nie reformatuje wewnętrznych danych OLE; może być wyświetlana jako obraz lub jako zewnętrznie edytowalna treść.

**Czy mogę zamienić czcionkę tylko w części prezentacji (według slajdów lub regionów)?**  
Ukierunkowana zamiana jest możliwa, jeśli zmienisz czcionkę na poziomie wymaganych obiektów/zakresów zamiast stosować globalną zamianę dla całego dokumentu. Ogólna logika wyboru czcionki podczas renderowania pozostaje taka sama.

**Jak mogę z góry określić, jakich czcionek używa prezentacja?**  
Użyj [menedżera czcionek](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/): dostarcza listę [używanych rodzin](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/getfonts/) oraz informacje o [zastąpieniach/„nieznane” czcionki](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsmanager/getsubstitutions/), co pomaga zaplanować zamianę.

**Czy zamiana czcionek działa przy konwertowaniu na PDF/obrazy?**  
Tak. Podczas eksportu Aspose.Slides stosuje tę samą [sekwencję wyboru/zastąpienia czcionek](/slides/pl/cpp/font-selection-sequence/), więc wcześniej wykonana zamiana zostanie uwzględniona podczas konwersji.

**Czy muszę zainstalować docelową czcionkę w systemie, czy mogę dołączyć folder czcionek?**  
Instalacja nie jest wymagana: biblioteka pozwala na [ładowanie zewnętrznych czcionek](/slides/pl/cpp/custom-font/) z folderów użytkownika do użycia podczas [renderowania i eksportu](/slides/pl/cpp/convert-powerpoint/).

**Czy zamiana naprawi „tofu” (kwadraty) zamiast znaków?**  
Tylko jeśli docelowa czcionka faktycznie zawiera wymagane glify. Jeśli nie, [skonfiguruj czcionki awaryjne](/slides/pl/cpp/fallback-font/) aby pokryć brakujące znaki.