---
title: Usprawnij zastępowanie czcionek w prezentacjach przy użyciu PHP
linktitle: Zastępowanie czcionek
type: docs
weight: 60
url: /pl/php-java/font-replacement/
keywords:
- czcionka
- zastąp czcionkę
- zastąpienie czcionki
- zmiana czcionki
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Bezproblemowo zastąp czcionki w Aspose.Slides dla PHP przy użyciu Java, aby zapewnić spójną typografię w prezentacjach PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia zastąpienie jednej czcionki drugą w całej prezentacji. Po zastąpieniu czcionki wszystkie wystąpienia oryginalnej czcionki zostają zmienione na nową czcionkę.

Aby wykonać zastąpienie czcionki, wczytaj prezentację, określ czcionkę źródłową i czcionkę zastępczą, wywołaj metodę zastąpienia czcionki i zapisz zmodyfikowaną prezentację jako plik PPTX. To podejście jest przydatne, gdy celowo chcesz przełączyć się z jednej rodziny czcionek na inną w całej prezentacji.

## **Zastępowanie czcionek**

Jeśli zmienisz zdanie co do używania czcionki, możesz zastąpić tę czcionkę inną. Wszystkie wystąpienia starej czcionki zostaną zastąpione nową czcionką.

Aspose.Slides umożliwia zastąpienie czcionki w następujący sposób:

1. Wczytaj odpowiednią prezentację. 
2. Wczytaj czcionkę, która ma zostać zastąpiona. 
3. Wczytaj nową czcionkę. 
4. Zastąp czcionkę. 
5. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod PHP demonstruje zastąpienie czcionki:

```php
  # Wczytuje prezentację
  $pres = new Presentation("Fonts.pptx");
  try {
    # Wczytuje czcionkę źródłową, którą będzie zastąpiono
    $sourceFont = new FontData("Arial");
    # Wczytuje nową czcionkę
    $destFont = new FontData("Times New Roman");
    # Zastępuje czcionki
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # Zapisuje prezentację
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
Aby ustawić reguły określające, co się stanie w określonych warunkach (np. gdy czcionka jest niedostępna), zobacz [**Zastąpienie czcionki**](/slides/pl/php-java/font-substitution/).
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między „zastąpieniem czcionki”, „substitucją czcionki” a „czcionkami zastępczymi”?**

Zastąpienie to celowy przeskok z jednej rodziny na drugą w całym dokumencie. [Substitucja](/slides/pl/php-java/font-substitution/) to reguła typu „jeśli czcionka jest niedostępna, użyj X”. [Czcionki zastępcze](/slides/pl/php-java/fallback-font/) są stosowane precyzyjnie dla pojedynczych brakujących glifów, gdy podstawowa czcionka jest zainstalowana, ale nie zawiera wymaganych znaków.

**Czy zastąpienie dotyczy slajdów master, układów, notatek i komentarzy?**

Tak. Zastąpienie wpływa na wszystkie obiekty prezentacji używające oryginalnej czcionki, w tym slajdy master i notatki; komentarze również są częścią dokumentu i są uwzględniane przez silnik czcionek.

**Czy czcionka zostanie zmieniona wewnątrz osadzonych obiektów OLE (np. Excel)?**

Nie. [Treść OLE](/slides/pl/php-java/manage-ole/) jest kontrolowana przez własną aplikację. Zastąpienie w prezentacji nie przekształca wewnętrznych danych OLE; może być wyświetlane jako obraz lub jako edytowalna zawartość zewnętrzna.

**Czy mogę zastąpić czcionkę tylko w części prezentacji (według slajdów lub regionów)?**

Ukierunkowane zastąpienie jest możliwe, jeśli zmienisz czcionkę na poziomie wymaganych obiektów/zakresów, zamiast stosować globalne zastąpienie w całym dokumencie. Logika wyboru czcionki podczas renderowania pozostaje niezmieniona.

**Jak mogę z góry określić, jakich czcionek używa prezentacja?**

Użyj [menedżera czcionek]((https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/)) prezentacji: zapewnia listę [używanych rodzin]((https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/getfonts/)) oraz informacje o [substitucjach/„nieznanych” czcionkach]((https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsmanager/getsubstitutions/)), co pomaga zaplanować zastąpienie.

**Czy zastąpienie czcionki działa przy konwersji do PDF/obrazów?**

Tak. Podczas eksportu Aspose.Slides stosuje tę samą [sekwencję wyboru/substitucji czcionek](/slides/pl/php-java/font-selection-sequence/), więc dokonane wcześniej zastąpienie zostanie uwzględnione podczas konwersji.

**Czy muszę zainstalować docelową czcionkę w systemie, czy mogę dołączyć folder czcionek?**

Instalacja nie jest wymagana: biblioteka umożliwia [ładowanie zewnętrznych czcionek](/slides/pl/php-java/custom-font/) z folderów użytkownika do użycia podczas [renderowania i eksportu](/slides/pl/php-java/convert-powerpoint/).

**Czy zastąpienie naprawi „tofu” (kwadraty) zamiast znaków?**

Tylko jeśli docelowa czcionka faktycznie zawiera wymagane glify. Jeśli nie, [skonfiguruj czcionki zastępcze](/slides/pl/php-java/fallback-font/), aby pokryć brakujące znaki.