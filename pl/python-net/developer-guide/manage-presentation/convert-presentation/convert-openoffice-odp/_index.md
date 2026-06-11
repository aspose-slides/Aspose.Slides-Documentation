---
title: Konwertuj prezentacje OpenDocument w Pythonie
linktitle: Konwertuj OpenDocument
type: docs
weight: 10
url: /pl/python-net/convert-openoffice-odp/
keywords:
- konwertuj OpenDocument
- konwertuj ODP
- ODP do PDF
- ODP do PPT
- ODP do PPTX
- ODP do XPS
- ODP do HTML
- ODP do TIFF
- ODP do SWF
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Konwertuj OpenDocument ODP do PDF, PPT, PPTX, XPS, HTML, TIFF lub SWF w Pythonie przy użyciu Aspose.Slides: przykłady kodu, wysoka wierność, konwersja wsadowa i dostosowanie."
---
## **Wstęp**

[**Aspose.Slides API**](https://products.aspose.com/slides/pl/python-net/) umożliwia konwertowanie prezentacji OpenDocument (ODP) do wielu formatów (HTML, PDF, TIFF, SWF, XPS, itp.). Interfejs API używany do konwertowania plików ODP na inne formaty dokumentów jest taki sam jak używany do operacji konwersji PowerPoint (PPT i PPTX).

Na przykład, jeśli potrzebujesz przekonwertować prezentację ODP do PDF, możesz to zrobić w następujący sposób:

```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **FAQ**

**Czy mogę konwertować ODP do PPTX bez instalacji LibreOffice lub OpenOffice?**

Tak. Aspose.Slides jest w pełni samodzielną biblioteką, która obsługuje zarówno formaty PowerPoint, jak i OpenOffice, nie wymagając żadnych zewnętrznych aplikacji.

**Czy Aspose.Slides otwiera i zapisuje pliki ODP/OTP zabezpieczone hasłem?**

Tak. Może [wczytać zaszyfrowane prezentacje](/slides/pl/python-net/password-protected-presentation/), gdy podasz hasło, oraz może zapisywać prezentacje z ustawieniami szyfrowania i ochrony.

**Czy mogę wyodrębnić osadzone pliki multimedialne (audio/wideo) z ODP przed konwersją?**

Tak. Aspose.Slides pozwala na dostęp i wyodrębnianie osadzonych [audio](/slides/pl/python-net/audio-frame/) i [video](/slides/pl/python-net/video-frame/) z prezentacji, co jest przydatne przy przetwarzaniu wstępnym przed konwersją lub przy oddzielnym wykorzystaniu.

**Czy mogę zapisać skonwertowany ODP jako Strict Office Open XML?**

Tak. Przy zapisywaniu do PPTX możesz włączyć Strict OOXML za pomocą [opcji zapisu](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pptxoptions/), aby spełnić surowsze wymogi zgodności.