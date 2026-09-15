---
title: AI-alapú prezentációfordító
linktitle: AI-alapú fordító
type: docs
weight: 20
url: /hu/androidjava/ai/translator/
keywords:
- AI prezentációfordító
- AI diafordító
- AI-alapú funkció
- többnyelvű prezentáció
- többnyelvű dia
- prezentációfordítás
- diafordítás
- AI-vezérelt funkciók
- AI képességek
- AI ügynök
- Web kliens
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Fordítsa le a PowerPoint diákat AI segítségével az Aspose.Slides for Android Java használatával. Lokálisan átalakítja a PPT, PPTX és ODP fájlokat, miközben megőrzi az elrendezést – gyors és fejlesztőbarát. Próbálja ki."
---
## **Bevezetés**

Az Aspose.Slides egy hatékony API a PowerPoint prezentációk programozott kezelésére. A diák létrehozása, szerkesztése és konvertálása mellett AI-alapú funkciókat kínál – például a Presentation Translation API-t a többnyelvű diatartalomhoz.

## **Hogyan működik**

Az Aspose.Slides nem tartalmaz beépített AI képességeket, hanem az interneten keresztül külső AI modellekkel integrálódik. Ez a funkció a [SlidesAIAgent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidesaiagent/) osztályon keresztül érhető el, amely a [IAIWebClient](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iaiwebclient/) interfész egy megvalósítását használja az AI szolgáltatásokkal való kommunikációhoz.

Használhatja a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/openaiwebclient/)‑t az OpenAI API-hoz való csatlakozáshoz, vagy megvalósíthatja saját [IAIWebClient](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iaiwebclient/)‑jét egy másik AI szolgáltató vagy nyelvi modell használatához.

Az Aspose.Slides kezeli a kommunikációt, értelmezi az AI válaszokat, és intelligensen beilleszti a lefordított tartalmat, miközben megőrzi az eredeti diák elrendezését és formázását.

{{% alert color="info" title="Note" %}}
Vegye figyelembe, hogy az OpenAI API fizetős szolgáltatás, ezért fiókot kell létrehoznia, és meg kell adnia az API kulcsát a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/openaiwebclient/) használata során.
{{% /alert %}}

## **Példa**

Ebben a példában egy PowerPoint prezentációt fordítunk japánra a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/openaiwebclient/) és egy megadott OpenAI [modellel](https://platform.openai.com/docs/models).

```java
import com.aspose.slides.*;

// Töltse be a lefordítandó prezentációt.
Presentation presentation = new Presentation("sample.pptx");

// Hozzon létre AI klienst az OpenAIWebClient használatával, megadva a modelljét és az API kulcsát.
OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null);

try {
    // Inicializálja a SlidesAIAgent-et az AI klienssel.
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);

    // Fordítsa le a prezentációt japánra.
    aiAgent.translate(presentation, "japanese");

    // Mentse el a lefordított prezentációt PDF-ként.
    presentation.save("sample_jp.pdf", SaveFormat.Pdf);
} finally {
    aiWebClient.close();
    presentation.dispose();
}
```

Alapértelmezés szerint a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/openaiwebclient/) saját belső [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html) példányt hoz létre és kezel, automatikusan kezelve annak életciklusát. Azonban ha magát szeretné kezelni a [HttpURLConnection](https://docs.oracle.com/javase/8/docs/api/java/net/HttpURLConnection.html)‑t – elsősorban egy proxy beállításához, vagy egy [URLStreamHandlerFactory](https://docs.oracle.com/javase/8/docs/api/java/net/URLStreamHandlerFactory.html) vagy egy másik [HttpClient](https://docs.oracle.com/en/java/javase/11/docs/api/java.net.http/java/net/http/HttpClient.html) használatához a jobb erőforrás-kezelés és teljesítmény érdekében – megadhatja saját `HttpURLConnection` példányát a [OpenAIWebClient](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/openaiwebclient/) példányosításakor.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URI;

try {
    //     Állítsa be saját magának az HttpURLConnection példányt (például egyedi időkorlátokkal, proxy beállításokkal stb.).
    HttpURLConnection urlConnection = (HttpURLConnection) URI.create("https://api.openai.com/v1/chat/completions").toURL().openConnection();
    urlConnection.setConnectTimeout(10000);
    urlConnection.setReadTimeout(60000);

    //     Adja át a kapcsolatot az OpenAIWebClient konstruktorának.
    OpenAIWebClient aiWebClient = new OpenAIWebClient("gpt-4o-mini", "apiKey", null, urlConnection);
} catch (IOException e) {
    e.printStackTrace();
}
```

### **Azure OpenAI példa**

Beállíthatja a fordítót, hogy az Azure OpenAI telepítését használja a [OpenAICompatibleWebClient](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/openaicompatiblewebclient/) segítségével.

```java
import com.aspose.slides.*;

String model = "your-azure-deployment-name";
String apiKey = "your-azure-api-key";
String baseUrl = "https://your-resource.openai.azure.com/openai/v1/";

OpenAICompatibleWebClient aiWebClient = new OpenAICompatibleWebClient(model, apiKey, baseUrl);
try {
    SlidesAIAgent aiAgent = new SlidesAIAgent(aiWebClient);
    Presentation presentation = new Presentation("Presentation.pptx");
    try {
        aiAgent.translate(presentation, "spanish");
        presentation.save("Translated.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    aiWebClient.dispose();
}
```

Ez a kódrészlet bemutatja egy prezentáció fordítását az Azure OpenAI végpontjával. Cserélje le a helyettesítő értékeket a telepítés nevére, az API kulcsra és a végpont URL‑re.

## **Fő előnyök**

Az Aspose.Slides Presentation Translation API AI-alapú megoldást kínál többnyelvű PowerPoint prezentációk biztosítására. A fordítás automatizálásával, miközben megőrzi az elrendezést és a dizájnt, időt takarít meg és csökkenti a hibákat a kézi munkafolyamatokhoz képest. Akár fejlesztő, oktató vagy üzleti szakember, ez az API lehetővé teszi, hogy vonzó, lokalizált prezentációkat készítsen a globális közönség számára – ezáltal növelve a elérést és javítva a kommunikációt.