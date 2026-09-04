---
title: "Tłumacz prezentacji zasilany sztuczną inteligencją"
linktitle: "Tłumacz zasilany AI"
type: docs
weight: 20
url: /pl/python-java/ai/translator/
keywords:
- "tłumacz prezentacji AI"
- "tłumacz slajdów AI"
- "wielojęzyczna prezentacja"
- "tłumaczenie prezentacji"
- "tłumaczenie slajdów"
- "PowerPoint"
- "OpenDocument"
- "Python"
- "Aspose.Slides"
description: "Tłumacz prezentacje przy użyciu AI za pomocą Aspose.Slides for Python via Java. Lokalizuj tekst slajdów i zapisz przetłumaczoną prezentację jako PowerPoint lub PDF."
---
## **Wprowadzenie**

Aspose.Slides for Python via Java udostępnia interfejs API tłumaczenia prezentacji AI do lokalizacji treści slajdów. Przetłumacz istniejącą prezentację na określony język, a następnie zapisz przetłumaczoną wersję w formacie, którego potrzebuje Twoja publiczność.

## **Jak to działa**

[SlidesAIAgent](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesaiagent/) komunikuje się z zewnętrzną usługą AI za pośrednictwem klienta AI. Przykłady używają wbudowanego [OpenAIWebClient](https://reference.aspose.com/slides/pl/python-java/aspose.slides/openaiwebclient/).

[SlidesAIAgent.translate](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesaiagent/#translate) aktualizuje przekazaną mu prezentację. Aspose.Slides przetwarza odpowiedzi AI i zastępuje tekst slajdów, zachowując istniejący układ i formatowanie. Przejrzyj wynik: przetłumaczony tekst może być dłuższy niż oryginalny i wymagać dostosowań układu.

## **Wymagania wstępne**

Postępuj zgodnie z instrukcją [Installation](/slides/pl/python-java/installation/), aby skonfigurować bibliotekę i jej środowisko uruchomieniowe. Ustaw zmienne środowiskowe `OPENAI_API_KEY` i `OPENAI_MODEL` przed uruchomieniem przykładów. Wybierz model obsługiwany przez wbudowanego klienta i dostępny w Twoim koncie API.

{{% alert color="info" title="Note" %}}
Tłumaczenie wymaga połączenia z internetem i wysyła tekst prezentacji do skonfigurowanej usługi AI. Dostęp do API i opłaty za jego użycie są oddzielne od licencji Aspose.Slides.
{{% /alert %}}

Przykłady ponownie wykorzystują aktywną JVM lub uruchamiają ją w razie potrzeby. Zobacz [JVM lifecycle guidance](/slides/pl/python-java/limitations-and-api-differences/#import-the-library) w celu uzyskania informacji o używaniu w notatniku.

## **Przetłumacz prezentację**

Umieść `sample.pptx` w katalogu roboczym. Ten przykład ładuje go przy użyciu [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), tłumaczy jego tekst na japoński i zapisuje wynik jako PDF. Zwalnia prezentację i zamyka klienta AI nawet w przypadku niepowodzenia operacji.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    presentation = Presentation("sample.pptx")
    try:
        ai_agent = SlidesAIAgent(ai_client)
        ai_agent.translate(presentation, "Japanese")
        presentation.save("sample_ja.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **Skonfiguruj połączenie HTTP**

Domyślnie [OpenAIWebClient](https://reference.aspose.com/slides/pl/python-java/aspose.slides/openaiwebclient/) zarządza swoim połączeniem HTTP wewnętrznie. Jego konstruktor z czterema argumentami akceptuje również zewnętrznie zarządzany obiekt Java [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html). Użyj tego przeciążenia, gdy musisz skonfigurować proxy lub limit czasu połączenia.

Poniższy przykład tworzy proxy HTTP Java przy użyciu [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) i otwiera połączenie przez [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)). Zastąp `proxy.example.com` i port własnymi ustawieniami proxy. Połączenie jest przekazywane bezpośrednio przez JPype; sesji HTTP Pythona nie można w tym miejscu użyć.

```python
import os
import jpype
import jpype.imports
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.net import InetSocketAddress, Proxy, URL
from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
proxy_address = InetSocketAddress("proxy.example.com", 8080)
proxy = Proxy(Proxy.Type.HTTP, proxy_address)
endpoint = URL("https://api.openai.com/v1/chat/completions")
connection = endpoint.openConnection(proxy)
try:
    connection.setConnectTimeout(30000)
    connection.setReadTimeout(60000)
    ai_client = OpenAIWebClient(model, api_key, None, connection)
    try:
        presentation = Presentation("sample.pptx")
        try:
            ai_agent = SlidesAIAgent(ai_client)
            ai_agent.translate(presentation, "Japanese")
            presentation.save("sample_ja.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        ai_client.close()
finally:
    connection.disconnect()
```

## **Kluczowe korzyści**

Automatyczne tłumaczenie pomaga przygotować wielojęzyczne materiały szkoleniowe, prezentacje produktów i raporty dla klientów, jednocześnie wykorzystując istniejący projekt slajdów. Zapisz edytowalną prezentację do dalszej weryfikacji lub wyeksportuj PDF do dystrybucji.

## **FAQ**

**Czy tłumaczenie tworzy oddzielny obiekt prezentacji?**

Nie. [SlidesAIAgent.translate](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesaiagent/#translate) modyfikuje dostarczoną prezentację. Zapisz ją pod nową nazwą pliku, aby zachować oryginalny plik niezmieniony.

**Jak określić język docelowy?**

Podaj nazwę języka, np. `"Japanese"` lub `"Spanish"`, jako drugi argument. Jakość tłumaczenia i zakres języków zależą od wybranego modelu.

**Czy mogę tłumaczyć bez użycia proxy?**

Tak. Użyj konstruktora klienta z trzema argumentami pokazanego w pierwszym przykładzie. Przykład własnego połączenia jest potrzebny tylko wtedy, gdy Twoja aplikacja wymaga explicite ustawień połączenia.