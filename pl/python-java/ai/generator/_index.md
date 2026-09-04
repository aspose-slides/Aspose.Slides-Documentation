---
title: Wielojęzyczny generator slajdów zasilany sztuczną inteligencją
linktitle: Generator zasilany sztuczną inteligencją
type: docs
weight: 40
url: /pl/python-java/ai/generator/
keywords:
- wielojęzyczna prezentacja
- wielojęzyczny slajd
- generator prezentacji AI
- generator slajdów AI
- szablon prezentacji
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Generuj wielojęzyczne prezentacje z tekstu przy użyciu Aspose.Slides for Python via Java. Wybierz szczegółowość treści, zastosuj szablon i wyeksportuj do PowerPoint lub PDF."
---
## **Wprowadzenie**

Generator prezentacji AI w Aspose.Slides for Python via Java tworzy prezentacje na podstawie opisów tematu, streszczeń, cytatów lub punktów wypunktowanych. Określ wymagany język w zapytaniu, wybierz ilość treści i opcjonalnie podaj szablon prezentacji, aby zdefiniować układ i projekt.

Generator strukturyzuje treść za pomocą bloków tekstowych, list wypunktowanych i tabel. Nie generuje obrazów; możesz dodać je do otrzymanej prezentacji później. Przejrzyj wygenerowaną treść i układ przed udostępnieniem prezentacji.

## **Jak to działa**

[SlidesAIAgent](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesaiagent/) używa klienta AI do komunikacji z zewnętrznym modelem. Poniższe przykłady korzystają z wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/python-java/aspose.slides/openaiwebclient/). Aspose.Slides przetwarza odpowiedzi modelu i buduje prezentację, którą możesz edytować lub eksportować.

Użyj [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesaiagent/#generatePresentation) z opisem tekstowym i wartością [PresentationContentAmountType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationcontentamounttype/). Przeciążenie z trzecim argumentem przyjmuje prezentację używaną jako szablon projektowy.

## **Wymagania wstępne**

Postępuj zgodnie z [Installation](/slides/pl/python-java/installation/), aby skonfigurować Python, Java, JPype i Aspose.Slides. Ustaw zmienne środowiskowe `OPENAI_API_KEY` i `OPENAI_MODEL` przed uruchomieniem przykładów. Wybierz model obsługiwany przez wbudowanego klienta i dostępny dla Twojego konta API.

{{% alert color="info" title="Uwaga" %}}
Usługa AI wymaga połączenia z Internetem i oddzielnego dostępu do API. Zapytania są wysyłane do skonfigurowanej usługi, a jej opłaty za użycie naliczane są niezależnie od licencji Aspose.Slides.
{{% /alert %}}

Każdy przykład uruchamia JVM tylko wtedy, gdy nie jest już uruchomiony, i pozostawia go dostępny dla kolejnych operacji. Zobacz [JVM lifecycle guidance](/slides/pl/python-java/limitations-and-api-differences/#import-the-library), dostosowując kod do notebooków.

## **Generowanie prezentacji z tekstu**

Ten przykład generuje prezentację w języku angielskim z [Medium](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationcontentamounttype/#Medium) ilością treści i zapisuje ją jako plik PowerPoint.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Generowanie prezentacji przy użyciu szablonu**

Umieść plik `masterPresentation.pptx` w katalogu roboczym. Ten przykład ładuje go przy pomocy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), generuje prezentację w języku hiszpańskim z treścią [Detailed](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationcontentamounttype/#Detailed) i eksportuje ją do PDF. Zarówno szablon, jak i wygenerowana prezentacja są zwalniane, nawet jeśli generowanie lub zapisywanie się nie powiedzie.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

Jeśli musisz skonfigurować proxy lub czasy oczekiwania połączenia, zobacz [Configure the HTTP Connection](/slides/pl/python-java/ai/translator/#configure-the-http-connection). Do generatora możesz także przekazać otrzymany klient.

## **Kluczowe korzyści**

Generowanie może zmniejszyć początkowy nakład pracy przy przygotowywaniu materiałów szkoleniowych, przeglądów produktów, raportów dla klientów i wewnętrznych prezentacji. Zapytania sterują tematem i językiem, a szablon pozwala ponownie wykorzystać istniejący projekt prezentacji.

## **FAQ**

**Jak kontrolować długość generowanej prezentacji?**

Wybierz [Brief](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationcontentamounttype/#Medium) lub [Detailed](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentationcontentamounttype/#Detailed). Ustawienia te wpływają zarówno na liczbę slajdów, jak i szczegółowość treści na każdym slajdzie; nie określają dokładnej liczby slajdów.

**Czy mogę generować slajdy w innym języku?**

Tak. Umieść żądany język w opisie tekstowym. Wynik zależy od możliwości językowych wybranego modelu.

**Czy mogę zachować wersję edytowalną przy eksporcie do PDF?**

Tak. Przed zwolnieniem wygenerowanej prezentacji, zapisz ją również jako PPTX, używając podejścia z pierwszego przykładu.