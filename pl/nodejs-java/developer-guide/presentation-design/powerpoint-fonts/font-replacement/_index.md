---
title: Usprawnij zastępowanie czcionek w prezentacjach przy użyciu JavaScript
linktitle: Zastępowanie czcionek
type: docs
weight: 60
url: /pl/nodejs-java/font-replacement/
keywords:
- czcionka
- zastąp czcionkę
- zastąpienie czcionki
- zmień czcionkę
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Bezproblemowo zastąp czcionki w JavaScript przy użyciu Aspose.Slides dla Node.js poprzez Java, aby zapewnić spójną typografię w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia zastąpienie jednej czcionki drugą w całej prezentacji. Po zastąpieniu czcionki wszystkie wystąpienia oryginalnej czcionki są zmieniane na nową czcionkę.

Aby wykonać zastąpienie czcionki, wczytaj prezentację, określ czcionkę źródłową i czcionkę zastępującą, wywołaj metodę zastąpienia czcionki i zapisz zmodyfikowaną prezentację jako plik PPTX. To podejście jest przydatne, gdy zamierzenie chcesz przełączyć jedną rodzinę czcionek na inną w całej prezentacji.

## **Zastępowanie czcionek**

Jeśli zmienisz zdanie co do używania czcionki, możesz zastąpić tę czcionkę inną. Wszystkie wystąpienia starej czcionki zostaną zastąpione nową czcionką.

Aspose.Slides umożliwia zastąpienie czcionki w następujący sposób:

1. Wczytaj odpowiednią prezentację. 
2. Wczytaj czcionkę, która ma zostać zastąpiona.
3. Wczytaj nową czcionkę. 
4. Zastąp czcionkę. 
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod JavaScript demonstruje zastąpienie czcionki:

```javascript
// Wczytuje prezentację
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Wczytuje czcionkę źródłową, która zostanie zastąpiona
    var sourceFont = new aspose.slides.FontData("Arial");
    // Wczytuje nową czcionkę
    var destFont = new aspose.slides.FontData("Times New Roman");
    // Zastępuje czcionki
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // Zapisuje prezentację
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
Aby ustawić reguły określające, co się dzieje w określonych warunkach (np. gdy czcionka jest niedostępna), zobacz [**Zastępowanie czcionek**](/slides/pl/nodejs-java/font-substitution/).
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między "zastąpieniem czcionki", "zastępowaniem czcionki" i "czcionkami zapasowymi"?**

Zastąpienie to celowe przełączenie z jednej rodziny na inną w całym dokumencie. [Zastępowanie](/slides/pl/nodejs-java/font-substitution/) to reguła typu „jeśli czcionka jest niedostępna, użyj X”. [Czcionki zapasowe](/slides/pl/nodejs-java/fallback-font/) są stosowane precyzyjnie dla pojedynczych brakujących glifów, gdy podstawowa czcionka jest zainstalowana, ale nie zawiera wymaganych znaków.

**Czy zastąpienie ma zastosowanie do slajdów głównych, układów, notatek i komentarzy?**

Tak. Zastąpienie wpływa na wszystkie obiekty prezentacji używające oryginalnej czcionki, w tym slajdy główne i notatki; komentarze również są częścią dokumentu i są uwzględniane przez silnik czcionek.

**Czy czcionka zmieni się wewnątrz osadzonych obiektów OLE (np. Excel)?**

Nie. [Zawartość OLE](/slides/pl/nodejs-java/manage-ole/) jest kontrolowana przez własną aplikację. Zastąpienie w prezentacji nie zmienia wewnętrznych danych OLE; może być wyświetlane jako obraz lub jako edytowalna zawartość zewnętrzna.

**Czy mogę zastąpić czcionkę tylko w części prezentacji (według slajdów lub regionów)?**

Zastąpienie celowane jest możliwe, jeśli zmienisz czcionkę na poziomie wymaganych obiektów/zakresów, a nie zastosujesz globalnego zastąpienia dla całego dokumentu. Ogólna logika wyboru czcionki podczas renderowania pozostaje niezmieniona.

**Jak mogę z góry określić, jakich czcionek używa prezentacja?**

Użyj [menedżera czcionek]https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/: zapewnia listę [używanych rodzin]https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getfonts/ i informacje o [zastąpieniach/"nieznanych" czcionkach]https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/, co pomaga w planowaniu zastąpienia.

**Czy zastąpienie czcionki działa przy konwertowaniu do PDF/obrazów?**

Tak. Podczas eksportu Aspose.Slides stosuje tę samą [sekwencję wyboru/zastępowania czcionek](/slides/pl/nodejs-java/font-selection-sequence/), więc wcześniej wykonane zastąpienie zostanie uwzględnione podczas konwersji.

**Czy muszę zainstalować docelową czcionkę w systemie, czy mogę dołączyć folder czcionek?**

Instalacja nie jest wymagana: biblioteka umożliwia [ładowanie czcionek zewnętrznych](/slides/pl/nodejs-java/custom-font/) z folderów użytkownika do użycia podczas [renderowania i eksportu](/slides/pl/nodejs-java/convert-powerpoint/).

**Czy zastąpienie naprawi „tofu” (kwadraty) zamiast znaków?**

Tylko jeśli docelowa czcionka rzeczywiście zawiera wymagane glify. Jeśli nie, [skonfiguruj czcionki zapasowe](/slides/pl/nodejs-java/fallback-font/), aby pokryć brakujące znaki.