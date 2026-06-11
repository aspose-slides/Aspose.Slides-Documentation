---
title: Usprawnij zastępowanie czcionek w prezentacjach na Androidzie
linktitle: Zastępowanie czcionek
type: docs
weight: 60
url: /pl/androidjava/font-replacement/
keywords:
- czcionka
- zamień czcionkę
- zastąpienie czcionki
- zmień czcionkę
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Bezproblemowo zastąp czcionki w Aspose.Slides dla Androida przy użyciu Javy, aby zapewnić spójną typografię w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia zastąpienie jednej czcionki inną w całej prezentacji. Gdy czcionka jest zastępowana, wszystkie wystąpienia oryginalnej czcionki są zmieniane na nową czcionkę.

Aby wykonać zastąpienie czcionki, wczytaj prezentację, określ czcionkę źródłową oraz czcionkę zastępczą, wywołaj metodę zastąpienia czcionki i zapisz zmodyfikowaną prezentację jako plik PPTX. To podejście jest przydatne, gdy celowo chcesz przejść z jednej rodziny czcionek na inną w całej prezentacji.

## **Zastąp czcionki**

Jeśli zmienisz zdanie co do używania czcionki, możesz zastąpić tę czcionkę inną. Wszystkie wystąpienia starej czcionki zostaną zastąpione nową czcionką.

Aspose.Slides umożliwia zastąpienie czcionki w następujący sposób:

1. Wczytaj odpowiednią prezentację. 
2. Wczytaj czcionkę, która ma zostać zastąpiona.
3. Wczytaj nową czcionkę. 
4. Zastąp czcionkę. 
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Java przedstawia zastąpienie czcionki:

```java
// Ładuje prezentację
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Ładuje czcionkę źródłową, która zostanie zastąpiona
    IFontData sourceFont = new FontData("Arial");
    
    // Ładuje nową czcionkę
    IFontData destFont = new FontData("Times New Roman");
    
    // Zastępuje czcionki
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Zapisuje prezentację
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Aby ustawić reguły określające, co się dzieje w określonych warunkach (np. gdy czcionka jest niedostępna), zobacz [**Podstawianie czcionek**](/slides/pl/androidjava/font-substitution/).
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między „zastąpieniem czcionki”, „podstawianiem czcionki” a „czcionkami awaryjnymi”?**

Zastąpienie to zamierzona zmiana z jednej rodziny czcionek na inną w całym dokumencie. [Podstawianie](/slides/pl/androidjava/font-substitution/) to reguła typu „jeśli czcionka jest niedostępna, użyj X”. [Czcionki awaryjne](/slides/pl/androidjava/fallback-font/) są stosowane precyzyjnie dla poszczególnych brakujących glifów, gdy podstawowa czcionka jest zainstalowana, ale nie zawiera wymaganych znaków.

**Czy zastąpienie dotyczy slajdów głównych, układów, notatek i komentarzy?**

Tak. Zastąpienie wpływa na wszystkie obiekty prezentacji wykorzystujące oryginalną czcionkę, w tym na slajdy główne i notatki; komentarze również są częścią dokumentu i są brane pod uwagę przez silnik czcionek.

**Czy czcionka zmieni się w osadzonych obiektach OLE (np. Excel)?**

Nie. [Zawartość OLE](/slides/pl/androidjava/manage-ole/) jest kontrolowana przez własną aplikację. Zastąpienie w prezentacji nie przekształca wewnętrznych danych OLE; mogą być wyświetlane jako obraz lub jako edytowalna zewnętrznie zawartość.

**Czy mogę zastąpić czcionkę tylko w części prezentacji (na slajdach lub w regionach)?**

Zastąpienie ukierunkowane jest możliwe, jeśli zmienisz czcionkę na poziomie wymaganego obiektu/zakresu, zamiast stosować globalne zastąpienie w całym dokumencie. Ogólna logika wyboru czcionki podczas renderowania pozostaje niezmieniona.

**Jak mogę z góry określić, z jakich czcionek korzysta prezentacja?**

Użyj [menedżera czcionek] prezentacji (https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsmanager/): zapewnia on listę [używanych rodzin czcionek] (https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsmanager/#getFonts--) oraz informacje o [podstawieniach/„nieznanych” czcionkach] (https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsmanager/#getSubstitutions--), co ułatwia planowanie zastąpienia.

**Czy zastąpienie czcionki działa przy konwersji do PDF/obrazów?**

Tak. Podczas eksportu Aspose.Slides stosuje tę samą [sekwencję wyboru/podstawiania czcionek](/slides/pl/androidjava/font-selection-sequence/), więc wcześniej wykonane zastąpienie zostanie uwzględnione przy konwersji.

**Czy muszę zainstalować docelową czcionkę w systemie, czy mogę dołączyć folder z czcionkami?**

Instalacja nie jest wymagana: biblioteka umożliwia [ładowanie zewnętrznych czcionek](/slides/pl/androidjava/custom-font/) z folderów użytkownika do użycia podczas [renderowania i eksportu](/slides/pl/androidjava/convert-powerpoint/).

**Czy zastąpienie naprawi „tofu” (kwadraty) zamiast znaków?**

Tylko jeśli docelowa czcionka rzeczywiście zawiera wymagane glify. Jeśli nie, [skonfiguruj czcionki awaryjne](/slides/pl/androidjava/fallback-font/), aby pokryć brakujące znaki.