---
title: AI-alapú többnyelvű dia generátor
linktitle: AI-alapú generátor
type: docs
weight: 40
url: /hu/python-java/ai/generator/
keywords:
- többnyelvű prezentáció
- többnyelvű dia
- AI prezentáció generátor
- AI dia generátor
- prezentáció sablon
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Készítsen többnyelvű prezentációkat szövegből az Aspose.Slides for Python via Java segítségével. Válassza ki a tartalom részletességét, alkalmazzon sablont, és exportáljon PowerPoint vagy PDF formátumba."
---
## **Bevezetés**

Az AI Prezentáció Generátor az Aspose.Slides for Python via Java-ban előadásokat hoz létre téma leírásokból, összefoglalókból, idézetekből vagy felsorolásokból. Adja meg a szükséges nyelvet a kérésben, válassza ki a tartalom mennyiségét, és opcionálisan adjon meg egy prezentációs sablont a elrendezés és a dizájn meghatározásához.

A generátor szöveges blokkok, felsorolások és táblázatok segítségével strukturálja a tartalmat. Nem generál képeket; ezeket a későbbiekben hozzáadhatja a létrehozott prezentációhoz. A megosztás előtt ellenőrizze a generált tartalmat és a elrendezést.

## **Hogyan működik**

[SlidesAIAgent](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidesaiagent/) egy AI ügyfelet használ a külső modellhez való kommunikációhoz. Az alábbi példák a beépített [OpenAIWebClient](https://reference.aspose.com/slides/hu/python-java/aspose.slides/openaiwebclient/) használatával működnek. Az Aspose.Slides feldolgozza a modell válaszait, és elkészíti a szerkeszthető vagy exportálható prezentációt.

Használja a [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slidesaiagent/#generatePresentation) metódust szöveges leírással és egy [PresentationContentAmountType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationcontentamounttype/) értékkel. A harmadik argumentummal rendelkező overload egy prezentációt fogad el tervezési sablonként.

## **Előfeltételek**

Kövesse az [Installation](/slides/hu/python-java/installation/) útmutatót a Python, Java, JPype és az Aspose.Slides konfigurálásához. A példák futtatása előtt állítsa be a `OPENAI_API_KEY` és `OPENAI_MODEL` környezeti változókat. Válasszon egy, a beépített ügyfél által támogatott és az API fiókjában elérhető modellt.

{{% alert color="info" title="Megjegyzés" %}}
Az AI szolgáltatáshoz internetkapcsolat és külön API hozzáférés szükséges. A kérések a beállított szolgáltatáshoz kerülnek elküldésre, és annak használati díjai az Aspose.Slides licencétől függetlenül érvényesek.
{{% /alert %}}

Minden példa csak akkor indítja el a JVM-et, ha az még nem fut, és elérhetővé hagyja a további műveletekhez. Lásd a [JVM lifecycle guidance](/slides/hu/python-java/limitations-and-api-differences/#import-the-library) útmutatót a kód notebook környezetbe való adaptálásakor.

## **Prezentáció generálása szövegből**

Ez a példa egy angol nyelvű prezentációt hoz létre közepes ([Medium](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationcontentamounttype/#Medium)) mennyiségű tartalommal, és PowerPoint fájlként menti.

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

## **Prezentáció generálása sablonnal**

Helyezze a `masterPresentation.pptx` fájlt a munkakönyvtárba. Ez a példa betölti azt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) segítségével, egy spanyol nyelvű prezentációt hoz létre részletes ([Detailed](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationcontentamounttype/#Detailed)) tartalommal, és PDF-be exportálja. Mind a sablon, mind a generált prezentáció felszabadításra kerül, még akkor is, ha a generálás vagy a mentés sikertelen.

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

Ha proxy-t vagy kapcsolati időkorlátokat kell beállítania, tekintse meg a [Configure the HTTP Connection](/slides/hu/python-java/ai/translator/#configure-the-http-connection) útmutatót. A keletkezett ügyfelet a generátornak is átadhatja.

## **Kulcsfontosságú előnyök**

A generálás csökkentheti a kiinduló vázlatkészítést képzési anyagok, termékáttekintések, ügyféljelentések és belső prezentációk esetén. A kérések szabályozzák a témát és a nyelvet, míg egy sablon lehetővé teszi egy meglévő prezentáció dizájn újrahasználatát.

## **GYIK**

**Hogyan szabályozhatom a generált prezentáció hosszát?**

Válassza a [Brief](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationcontentamounttype/#Brief), [Medium](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationcontentamounttype/#Medium) vagy a [Detailed](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationcontentamounttype/#Detailed) opciót. Ezek a beállítások befolyásolják a diák számát és a részletességet is, de nem határoznak meg pontos diaszámot.

**Generálhatok diákat más nyelven?**

Igen. Adja meg a kért nyelvet a szöveges leírásban. Az eredmény a kiválasztott modell nyelvi lehetőségeitől függ.

**Megőrizhetek szerkeszthető verziót PDF-exportáláskor?**

Igen. A generált prezentáció eldobása előtt mentse azt PPTX formátumban is az első példában bemutatott módon.