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
description: "Ellenőrizze, hogy az Aspose.Slides for Java telepítése előtt mire van szüksége: a támogatott Java verziókra és operációs rendszerekre, valamint a Linux által igényelt betűtípus‑könyvtárra és betűtípusokra."
---
## **Bevezetés**

Aspose.Slides for Java egy önálló könyvtár: nem igényel Microsoft PowerPointot vagy Microsoft Office‑t. Egyetlen JAR fájl, amely az Aspose Maven tárolójában érhető el. A JAR fájl csak Java osztályokat és erőforrásokat tartalmaz, nem tartalmaz natív könyvtárakat, és nem deklarál függőségeket más könyvtárakra. Így ugyanez a fájl minden olyan operációs rendszeren és processzoron fut, amelyhez elérhető támogatott Java futtatókörnyezet.

Ez a cikk felsorolja a támogatott Java verziókat és operációs rendszereket, valamint a Linux számára szükséges betűtípus‑könyvtárat és betűtípusokat, majd egy rövid programmal ellenőrzi a beállítást. A könyvtár projekthez való hozzáadásához lásd a [Telepítés](/slides/hu/java/installation/) oldalt.

## **Támogatott Java verziók**

Az Aspose.Slides for Java Java 8‑as vagy újabb JDK‑val vagy JRE‑vel működik. Ez magában foglalja a hosszú távú támogatású kiadásokat: Java 8, 11, 17, 21 és 25, valamint a későbbi kiadásokat, például Java 26 és Java 27. A Java futtatókörnyezet származhat bármely gyártótól, például Eclipse Temurin, Amazon Corretto, Oracle vagy egy Linux disztribúció OpenJDK csomagja.

Az Aspose.Slides nem igényel JVM‑opciókat, például `--add-opens`‑t, ezen verziók bármelyikén. Java 11‑nél a JVM egy „WARNING: An illegal reflective access operation has occurred” üzenetet jelenít meg; ez nem befolyásolja az eredményt.

{{% alert color="warning" title="Warning" %}}
A Java 6 és a Java 7 elavult. Az Aspose.Slides for Java 26.9 még fut rajtuk, de elavulási figyelmeztetést ad. A 26.10‑es verziótól kezdve a minimum Java 8, a Java 6 és Java 7 már nem támogatott.
{{% /alert %}}

A Maven projekt és a [Telepítés](/slides/hu/java/installation/) parancsai JDK 11‑et vagy újabbat igényelnek. Java 8‑al a programot a [Ellenőrizze a beállítást](#check-your-setup) részben leírt módon kell lefordítani és futtatni.

## **Támogatott operációs rendszerek**

Mivel a JAR fájl nem tartalmaz natív kódot, az Aspose.Slides for Java Windows, Linux és macOS rendszereken, bármely, a Java futtatókörnyezet által támogatott processzorarchitektúrán (például x64 és ARM64) fut. Windowson a Java futtatókörnyezet az egyetlen követelmény. Linuxon a Java‑betűtípus‑támogatás további fontconfig könyvtárat és betűtípusokat igényel, amelyeket a [Linux](#linux) rész ír le.

## **Linux**

Az Aspose.Slides for Java a Java futtatókörnyezet betűtípus‑támogatásával helyezi el és rajzolja meg a szöveget. Linuxon ez a támogatás fontconfig könyvtárat és legalább egy telepített betűtípust igényel. A hivatalos Linux‑konténerképek gyakran egyikét sem tartalmazzák. Enélkül az első példa a [Prezentációk létrehozása](/slides/hu/java/create-presentation/) című oldalon a prezentáció mentésekor hibát jelez, üres fájlt hagy és a következő üzenetet adja:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

A hivatalos `eclipse-temurin` konténerképek Ubuntu‑ra és Alpine Linux‑ra már tartalmazzák a fontconfig‑ot és a DejaVu betűtípusokat, így nincs szükség további telepítésre. Más rendszereken telepítsd az alábbi csomagokat. A Debian, Ubuntu és Red Hat parancsok `sudo`‑t használnak; Dockerfile‑ban futtasd őket `RUN` utasítással `sudo` nélkül. A DejaVu betűtípusok elegendőek az Aspose.Slides működéséhez; a prezentációkban használt betűtípusokkal kapcsolatos részletek a [Betűtípusok](#fonts) szakaszban találhatók.

### **Debian és Ubuntu**

Ha a Debian vagy Ubuntu csomagokból telepíted a Javat az alapértelmezett `apt-get` beállításokkal, ahogy a [Telepítés](/slides/hu/java/installation/#linux) parancs teszi, a Java csomagok automatikusan telepítik a fontconfig könyvtárat, a DejaVu betűtípusokat és a HarfBuzz könyvtárat, amelyre ezek a Java csomagoknak szükségük van, és egyéb további csomagra nincs szükség.

Más forrásból származó Java futtatókörnyezet esetén, például egy Eclipse Temurin archívumból, telepítsd a fontconfig‑ot és a DejaVu betűtípusokat:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Egy Dockerfile gyakran a Debian vagy Ubuntu Java csomagokat telepíti, például `openjdk-21-jdk-headless` vagy `default-jdk-headless`, a `--no-install-recommends` kapcsolóval, amely kihagyja mindhárom csomagot. Telepítsd a fontconfig‑ot és a DejaVu betűtípusokat a fenti paranccsal, és add hozzá a HarfBuzz‑t is:

```bash
sudo apt-get install -y libharfbuzz0b
```

Harfbuzz nélkül ezek a Java csomagok a következő üzenetet írják: `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, és a mentés `UnsatisfiedLinkError`‑rel sikertelen, amely azt jelzi, hogy a `libharfbuzz.so.0` nem nyitható meg.

### **Red Hat Enterprise Linux**

A Red Hat Enterprise Linux `java-<version>-openjdk-headless` csomagjai nem telepítik a fontconfig könyvtárat. Telepítsd azt a DejaVu betűtípusokkal együtt:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

A teljes `java-<version>-openjdk` csomagok a fontconfig‑ot és a betűtípusokat függőségként telepítik, és ugyanez igaz az Amazon Corretto csomagokra az Amazon Linux 2023‑ban, például a `java-21-amazon-corretto-headless` csomagra.

### **Alpine Linux**

Alpine Linux‑alapú Dockerfile‑ban telepítsd a fontconfig‑ot és a DejaVu betűtípusokat:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

Az aktuális Alpine kiadásoknál a `ttf-dejavu` a `font-dejavu` csomagot telepíti. Telepíts Java‑t az `openjdk<version>-jre` vagy `openjdk<version>-jdk` csomaggal, például `openjdk25-jdk`. Az Alpine Linux `openjdk<version>-jre-headless` csomagjai nem tartalmazzák a Java betűtípus‑könyvtárát, ezért ilyen esetben a program `UnsatisfiedLinkError: no fontmanager in system library path` hibával áll le, még ha a betűtípusok telepítve vannak is.

### **Betűtípusok**

A szöveg helyes betűtípusokkal és metrikákkal történő megjelenítéséhez a prezentációk által használt betűtípusoknak vagy megfelelő helyettesítőknek a rendszerben kell telepítve lenniük, vagy az alkalmazás által be kell töltődniük. Lásd a [Betűtípusok telepítése](/slides/hu/java/deploy-fonts/), a [Betűtípus‑helyettesítés](/slides/hu/java/font-substitution/) és a [Egyéni betűtípusok](/slides/hu/java/custom-font/) oldalakat.

## **Ellenőrizze a beállítást**

A könyvtár és a követelmények meglétének ellenőrzéséhez futtass egy programot, amely prezentációt ment és egy diát képpé konvertál. A mentés és a konvertálás a Java futtatókörnyezet betűtípus‑támogatását használja, amelyet a fenti Linux‑követelmények biztosítanak.

Mentsd el az alábbi kódot *CheckSetup.java* néven abba a mappába, amely az Aspose.Slides JAR fájlt tartalmazza. A JAR fájl letöltéséhez lásd a [A JAR‑fájl használata Maven nélkül](/slides/hu/java/installation/#use-the-jar-file-without-maven) oldalt.

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

            // Rendereljük a diát egy pixel pontonként, és mentsük a képet.
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

JDK 11‑el vagy újabbal futtasd a programot az alábbi parancs segítségével abban a mappában. Ha a JAR fájl neve más, módosítsd a parancsban a nevet.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

Java 8‑al, vagy ha csak JRE áll rendelkezésre, fordítsd le a programot `javac`‑vel egy JDK‑ból, majd futtasd a lefordított osztályt. Linuxon és macOS‑on futtasd:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

Windows‑on futtasd ugyanazt a `javac` parancsot, majd a osztályt pontosvesszővel elválasztott osztályút‑választóval. Tartsd meg az idézőjeleket, hogy a PowerShell ne a pontosvesszőt a parancs végeként értelmezze: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

A program egy téglalapot szöveggel ad az első diára, és a prezentációt *hello.pptx* néven menti a [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódussal. Ezután a diát a [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) metódussal képpé konvertálja, és az eredményt *hello.png* néven a [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) metódus segítségével az [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/) formátumban menti. Az 1‑es méretezési tényező egy pixelt jelenít meg pontonként, így az alapértelmezett 720 × 540 pont méretű dia 720 × 540 pixeles képpé alakul, a szöveg a téglalapon belül látható. Licenc nélkül mindkét fájl értékelési vízjelet tartalmaz; lásd a [Licencelés](/slides/hu/java/licensing/) oldalt. Ha valamelyik követelmény hiányzik, a program a [Linux](#linux) részben leírt hibák egyikével leáll.

## **Fejlesztői eszközök**

Az Aspose.Slides‑ot bármely, támogatott Java verzióval kompatibilis JDK‑vel használhatod. Használj Apache Maven‑t az Aspose Maven tárolójával, ahogyan a [Telepítés](/slides/hu/java/installation/) leírja, vagy bármely más build‑eszközt, amely Maven tárolót képes használni. A JAR fájlt saját kezűleg is hozzáadhatod az IDE‑d vagy a build‑eszközöd osztályútjához.

## **GYIK**

**Szükség van Microsoft PowerPoint telepítésére a konvertáláshoz és a rendereléshez?**

Nem, a PowerPoint nem kötelező. Az Aspose.Slides egy önálló motor a [prezentációk létrehozásához](/slides/hu/java/create-presentation/), módosításához, [konvertálásához](/slides/hu/java/convert-presentation/) és [rendereléséhez](/slides/hu/java/convert-powerpoint-to-png/).

**Az Aspose.Slides for Java igényel kijelzőt vagy asztali környezetet egy Linux szerveren?**

Nem. Az Aspose.Slides nem igényel X‑szervert vagy kijelzőt, így szervereken és konténerekben egyaránt futtatható. Linuxon csak a [Linux](#linux) részben leírt betűtípus‑könyvtár és betűtípusok szükségesek.

**Milyen betűtípusokra van szükség a helyes megjelenítéshez?**

A prezentációban használt betűtípusoknak vagy megfelelő [helyettesítőknek](/slides/hu/java/font-substitution/) elérhetőnek kell lenniük. Linuxon és macOS‑on telepítsd a prezentációkhoz szükséges betűtípus‑csomagokat a következetes megjelenítés érdekében.

**Miért jelenik meg egy egyéni betűtípus helyettesítőként vagy hiányzó szövegként Linuxon?**

Ha a betűtípusfájl névtábla-bejegyzései nem egységesek vagy sérültek, a Linux betűtípus‑illesztő réteg (FreeType/fontconfig) érvénytelen rekordot választhat, ami a betűtípus feloldásának hibáját okozza. A javított névtábla‑rekordokkal rendelkező betűtípus verziójának használata vagy egy konzisztens helyettesítő telepítése megoldja a problémát.