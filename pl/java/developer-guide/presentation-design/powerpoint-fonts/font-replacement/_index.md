---
title: Usprawnij zastępowanie czcionek w prezentacjach przy użyciu Java
linktitle: Zastępowanie czcionek
type: docs
weight: 60
url: /pl/java/font-replacement/
keywords:
- czcionka
- zastąp czcionkę
- zastąpienie czcionki
- zmiana czcionki
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Bezproblemowo zastępuj czcionki w Aspose.Slides for Java, aby zapewnić spójną typografię w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia zastąpienie jednej czcionki inną w całej prezentacji. Gdy czcionka zostanie zastąpiona, wszystkie wystąpienia pierwotnej czcionki zostają zmienione na nową czcionkę.

Aby wykonać zastąpienie czcionki, wczytaj prezentację, określ czcionkę źródłową i czcionkę zastępującą, wywołaj metodę zastąpienia czcionki i zapisz zmodyfikowaną prezentację jako plik PPTX. To podejście jest przydatne, gdy zamierzasz celowo przełączyć się z jednej rodziny czcionek na inną w całej prezentacji.

## **Zastępowanie czcionek**

Jeśli zmienisz zdanie co do używania czcionki, możesz zastąpić tę czcionkę inną. Wszystkie wystąpienia starej czcionki zostaną zastąpione nową.

Aspose.Slides umożliwia zastąpienie czcionki w następujący sposób:

1. Wczytaj odpowiednią prezentację. 
2. Wczytaj czcionkę, która ma zostać zastąpiona.
3. Wczytaj nową czcionkę. 
4. Zastąp czcionkę. 
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

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

Aby ustawić reguły określające, co się stanie w określonych warunkach (np. gdy czcionka nie jest dostępna), zobacz [**Font Substitution**](/slides/pl/java/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Jaka jest różnica między "font replacement", "font substitution" i "fallback fonts"?**

Zastąpienie to zamierzona zmiana z jednej rodziny na inną w całym dokumencie. [Substitution](/slides/pl/java/font-substitution/) to reguła typu „jeśli czcionka jest niedostępna, użyj X”. [Fallback](/slides/pl/java/fallback-font/) jest stosowany celowo dla pojedynczych brakujących glifów, gdy podstawowa czcionka jest zainstalowana, ale nie zawiera wymaganego znaku.

**Czy zastąpienie dotyczy slajdów głównych, układów, notatek i komentarzy?**

Tak. Zastąpienie wpływa na wszystkie obiekty prezentacji używające pierwotnej czcionki, w tym slajdy główne i notatki; komentarze również są częścią dokumentu i są uwzględniane przez silnik czcionek.

**Czy czcionka zmieni się w osadzonych obiektach OLE (np. Excel)?**

Nie. [OLE content](/slides/pl/java/manage-ole/) jest kontrolowany przez swoją własną aplikację. Zastąpienie w prezentacji nie reformatuje wewnętrznych danych OLE; mogą być wyświetlane jako obraz lub jako edytowalna zewnętrznie zawartość.

**Czy mogę zastąpić czcionkę tylko w części prezentacji (według slajdów lub regionów)?**

Zastąpienie ukierunkowane jest możliwe, jeśli zmienisz czcionkę na poziomie wymaganych obiektów/zakresów, zamiast stosować globalne zastąpienie w całym dokumencie. Ogólna logika wyboru czcionki podczas renderowania pozostaje niezmieniona.

**Jak mogę z góry określić, jakich czcionek używa prezentacja?**

Użyj menedżera czcionek prezentacji [font manager](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsmanager/): zapewnia listę używanych [families in use](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsmanager/#getFonts--) oraz informacji o [substitutions/"unknown" fonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsmanager/#getSubstitutions--), co pomaga w planowaniu zastąpienia.

**Czy zastąpienie czcionki działa przy konwersji do PDF/obrazów?**

Tak. Podczas eksportu Aspose.Slides stosuje tę samą [font selection/substitution sequence](/slides/pl/java/font-selection-sequence/), więc wcześniej wykonane zastąpienie zostanie uwzględnione podczas konwersji.

**Czy muszę zainstalować docelową czcionkę w systemie, czy mogę dołączyć folder czcionek?**

Instalacja nie jest wymagana: biblioteka umożliwia [loading external fonts](/slides/pl/java/custom-font/) z folderów użytkownika do użycia podczas [rendering and export](/slides/pl/java/convert-powerpoint/).

**Czy zastąpienie naprawi „tofu” (kwadraty) zamiast znaków?**

Tylko jeśli docelowa czcionka rzeczywiście zawiera wymagane glify. Jeśli nie, [configure fallback](/slides/pl/java/fallback-font/) aby pokryć brakujące znaki.