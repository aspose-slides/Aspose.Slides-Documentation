---
title: Rendszerkövetelmények
type: docs
weight: 60
url: /hu/java/system-requirements/
keywords:
- rendszerkövetelmények
- támogatott platformok
- Java verziók
- JDK
- JRE
- fontconfig
- betűtípusok
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Ellenőrizze, hogy az Aspose.Slides for Java telepítése előtt milyen követelményekkel rendelkezik: a támogatott Java verziók és operációs rendszerek, valamint a Linux által igényelt betűtípus-könyvtár és betűtípusok."
---
## **Bevezetés**

Az Aspose.Slides for Java egy önálló könyvtár: nem igényli a Microsoft PowerPointot vagy a Microsoft Office-ot. Egyetlen JAR fájl, amely az Aspose Maven tárolójában van közzétéve. A JAR fájl csak Java osztályokat és erőforrásokat tartalmaz, nincsenek natív könyvtárak, és nem deklarál függőségeket más könyvtárakra. Ez a fájl ezért minden operációs rendszeren és processzoron fut, amelyhez elérhető támogatott Java futtatókörnyezet.

Ez a cikk felsorolja a támogatott Java verziókat és operációs rendszereket, valamint a Linuxnak szükséges betűtípus‑könyvtárat és betűtípusokat, és egy rövid programmal zárul, amely ellenőrzi a beállításokat. A könyvtár projektbe történő hozzáadásához lásd a [Telepítés](/slides/hu/java/installation/) oldalt.

## **Támogatott Java verziók**

Az Aspose.Slides for Java a Java 8 vagy újabb verzióval fut, JDK-val vagy JRE‑vel. Ez magában foglalja a hosszú távú támogatású kiadásokat: Java 8, 11, 17, 21 és 25, valamint későbbi kiadásokat, például Java 26 és Java 27. A Java futtatókörnyezet származhat bármely szállítótól, például Eclipse Temurin, Amazon Corretto, Oracle vagy egy Linux disztribúció OpenJDK csomagjaiból.

Az Aspose.Slides nem igényel JVM opciókat, például a `--add-opens`‑t, ezekben a verziókban. Java 11 esetén a JVM egy figyelmeztetést ír ki, amely a következővel kezdődik: "WARNING: An illegal reflective access operation has occurred"; a figyelmeztetés nem befolyásolja az eredményt.

{{% alert color="warning" title="Warning" %}}
A Java 6 és Java 7 elavult. Az Aspose.Slides for Java 26.9 még fut ezeken, de elavulási figyelmeztetést jelenít meg. A 26.10‑es verziótól a Java 8 a minimum, a Java 6 és Java 7 már nem támogatott.
{{% /alert %}}

A Maven projekt és a [Telepítés](/slides/hu/java/installation/) parancsai JDK 11 vagy újabb verziót igényelnek. Java 8 esetén fordítsa le és futtassa a programot az [Ellenőrizze a beállításait](#check-your-setup) szakaszban leírtak szerint.

## **Támogatott operációs rendszerek**

Mivel a JAR fájl nem tartalmaz natív kódot, az Aspose.Slides for Java a Windows, Linux és macOS rendszereken, bármely olyan processzorarchitektúrán fut, amelyet a Java futtatókörnyezet támogat, például x64 és ARM64. Windows esetén a Java futtatókörnyezet az egyetlen követelmény. Linuxon a Java betűtípus-támogatásnak szüksége van a [Linux](#linux) részben leírt betűtípus‑könyvtárra és betűtípusokra.

## **Linux**

Az Aspose.Slides for Java a Java futtatókörnyezet betűtípus‑támogatásával helyezi el és rajzolja a szöveget. Linuxon ez a támogatás a fontconfig könyvtárat és legalább egy telepített betűtípust igényel. A Linux disztribúciók hivatalos konténerképei gyakran egyikük sem tartalmazzák. Ezek hiányában az első példa a [Prezentációk létrehozása](/slides/hu/java/create-presentation/) oldalon hibát jelez, amikor a prezentációt menti, üres fájlt hagy, és a következő hibát jelzi:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

A hivatalos `eclipse-temurin` konténerképek, Ubuntu és Alpine Linux esetén már tartalmazzák a fontconfig‑ot és a DejaVu betűtípusokat, így semmit sem kell telepíteni rajtuk. Más rendszereken telepítse az alábbi csomagokat. A Debian, Ubuntu és Red Hat parancsok `sudo`‑t használnak; Dockerfile‑ban futtassa őket `RUN` utasításban `sudo` nélkül. A DejaVu betűtípusok elegendőek az Aspose.Slides futtatásához; a prezentációk által használt betűtípusok a [Betűtípusok](#fonts) szakaszban vannak leírva.

### **Debian és Ubuntu**

Ha a Java‑t a Debian vagy Ubuntu csomagokból telepíti az alapértelmezett `apt-get` beállításokkal, ahogy a [Telepítés](/slides/hu/java/installation/#linux) parancs teszi, a Java csomagok telepítik a fontconfig könyvtárat, a DejaVu betűtípusokat, valamint a HarfBuzz könyvtárat, amelyre ezeknek a Java csomagoknak szükségük van, és más nem szükséges.

Más forrásból származó Java futtatókörnyezettel, például egy Eclipse Temurin archívummal, telepítse a fontconfig‑ot és a DejaVu betűtípusokat:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Egy Dockerfile gyakran telepíti a Debian vagy Ubuntu Java csomagokat, például `openjdk-21-jdk-headless` vagy `default-jdk-headless`, a `--no-install-recommends` opcióval, amely kihagyja mindháromat. Telepítse a fontconfig‑ot és a DejaVu betűtípusokat a fenti paranccsal, és telepítse a HarfBuzz‑ot is:

```bash
sudo apt-get install -y libharfbuzz0b
```

HarfBuzz nélkül ezek a Java csomagok a `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless` üzenetet írják ki, és a mentés `UnsatisfiedLinkError` hibával sikertelen, amely azt jelzi, hogy a `libharfbuzz.so.0` nem nyitható meg.

### **Red Hat Enterprise Linux**

A Red Hat Enterprise Linux `java-<version>-openjdk-headless` csomagjai nem telepítik a fontconfig könyvtárat. Telepítse azt a DejaVu betűtípusokkal együtt:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

A teljes `java-<version>-openjdk` csomagok függőségként telepítik a fontconfig‑ot és a betűtípusokat, és ez az Amazon Linux 2023 Amazon Corretto csomagjai esetén is így van, például a `java-21-amazon-corretto-headless` esetén.

### **Alpine Linux**

Alpine Linux alapú Dockerfile‑ban telepítse a fontconfig‑ot és a DejaVu betűtípusokat:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

A jelenlegi Alpine kiadásokban a `ttf-dejavu` telepíti a `font-dejavu` csomagot. Telepítse a Java‑t a `openjdk<version>-jre` vagy `openjdk<version>-jdk` csomaggal, például `openjdk25-jdk`. Az Alpine Linux `openjdk<version>-jre-headless` csomagjai nem tartalmazzák a Java betűtípus‑könyvtárát, ezért ezekkel a program `UnsatisfiedLinkError: no fontmanager in system library path` hibával kudarcot vall, még ha a betűtípusok telepítve vannak is.

### **Betűtípusok**

A szöveg helyes betűtípusokkal és metrikákkal való megjelenítéséhez a prezentációk által használt betűtípusoknak vagy megfelelő helyettesítőknek telepítve kell lenniük a rendszerben vagy az alkalmazás által betöltve. Lásd a [Betűtípusok telepítése](/slides/hu/java/deploy-fonts/), [Betűtípus helyettesítése](/slides/hu/java/font-substitution/) és [Egyedi betűtípusok](/slides/hu/java/custom-font/) oldalakat.

## **Ellenőrizze a beállításait**

A könyvtár és követelményei helyességének ellenőrzéséhez futtasson egy programot, amely ment egy prezentációt és egy diát képként renderel. A mentés és a renderelés a Java futtatókörnyezet betűtípus‑támogatását használja, amit a fenti Linux követelmények biztosítanak.

Mentse az alábbi kódot *CheckSetup.java* néven abba a mappába, amely az Aspose.Slides JAR fájlt tartalmazza. A JAR fájl letöltéséhez lásd a [Használja a JAR fájlt Maven nélkül](/slides/hu/java/installation/#use-the-jar-file-without-maven) oldalt.

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // Adjunk hozzá egy téglalapot szöveggel az első diára, és mentsük a prezentációt.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Rendereljük a diát egy pixel per pont méretben, és mentsük el a képet.
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

JDK 11 vagy újabb verzióval futtassa a programot abban a mappában a lentebb lévő paranccsal. Ha a JAR fájl neve eltér, módosítsa a neveket a parancsokban.

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

Java 8 esetén, vagy egy olyan rendszeren, amely csak JRE‑t tartalmaz, a programot fordítsa `javac`‑vel egy JDK‑ból, majd futtassa a lefordított osztályt. Linuxon és macOS‑en futtassa:

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

Windowson futtassa ugyanazt a `javac` parancsot, majd futtassa az osztályt pontosvesszővel a classpath elválasztóként. Tartsa meg az idézőjeleket, hogy a PowerShell ne tekintse a pontosvesszőt a parancs végének: `java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

A program egy téglalapot szöveggel ad az első diához, és a prezentációt *hello.pptx* néven menti a [mentés](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódussal. Ezután a diát a [getImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slide/#getImage-float-float-) metódussal rendereli, és az eredményt *hello.png* néven menti az [IImage.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iimage/#save-java.lang.String-int-) metódussal a [ImageFormat.Png](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imageformat/) formátumban. Az 1-es méretezési tényezők pontot per pontot renderelnek, így az alapértelmezett 720 × 540 pont méretű dia 720 × 540 képpontos képpé alakul, a szöveg látható a téglalapon belül. Licenc nélkül mindkét fájl értékelő vízjelhez kap; lásd a [Licencelés](/slides/hu/java/licensing/) oldalt. Ha egy követelmény hiányzik, a program a [Linux](#linux) részben leírt hibák egyikével leáll.

## **Fejlesztői eszközök**

Alkalmazásokat építhet, amelyek az Aspose.Slides‑t használják, bármely támogatott Java verzió JDK‑jával. Használjon Apache Maven‑t az Aspose Maven tárolójával, ahogy a [Telepítés](/slides/hu/java/installation/) leírásában szerepel, vagy bármely más építőeszközt, amely Maven tárolót képes használni. A JAR fájlt saját magának is hozzáadhatja az IDE‑je vagy építőeszköze classpath‑jához.

## **GYIK**

**Szükségem van a Microsoft PowerPoint telepítésére a konverziókhoz és a rendereléshez?**

Nem, a PowerPoint nem szükséges. Az Aspose.Slides egy önálló motor a [létrehozáshoz](/slides/hu/java/create-presentation/), módosításhoz, [konvertáláshoz](/slides/hu/java/convert-presentation/) és [rendereléshez](/slides/hu/java/convert-powerpoint-to-png/) prezentációkhoz.

**Igényel az Aspose.Slides for Java megjelenítőt vagy asztali környezetet egy Linux szerveren?**

Nem. Az Aspose.Slides nem igényel X szervert vagy megjelenítőt, ezért szervereken és konténerekben is fut. Linuxon csak a [Linux](#linux) szekcióban leírt betűtípus‑könyvtárra és betűtípusokra van szüksége.

**Mely betűtípusok szükségesek a helyes megjelenítéshez?**

A prezentációban használt betűtípusoknak, vagy megfelelő [helyettesítőknek](/slides/hu/java/font-substitution/), elérhetőnek kell lenniük. Linuxon és macOS‑en telepítse a prezentációk számára szükséges betűtípuscsomagokat a konzisztens megjelenítés érdekében.

**Miért jelenik meg egy egyedi betűtípus helyettesítőként vagy hiányzó szövegként Linuxon?**

Ha a betűtípusfájlban ellentmondásos vagy sérült névtábla‑bejegyzések vannak, a Linux betűtípus‑illesztő stack (FreeType/fontconfig) érvénytelen rekordot választhat, ami a betűtípus feloldásának hiányához vezet. Egy javított névtábla‑bejegyzésekkel rendelkező betűtípus verzió használata vagy egy konzisztens csere telepítése megoldja a problémát.