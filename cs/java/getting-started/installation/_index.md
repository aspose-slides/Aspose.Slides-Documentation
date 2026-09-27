---
title: Instalace
type: docs
weight: 70
url: /cs/java/installation/
keywords:
- instalovat Aspose.Slides
- stáhnout Aspose.Slides
- použít Aspose.Slides
- instalace Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Instalujte Aspose.Slides pro Java z Maven repozitáře společnosti Aspose nebo jako soubor JAR, nastavte požadavky na Linux a ověřte instalaci pomocí prvního programu."
---
## **Přehled**

Tento článek popisuje, jak přidat Aspose.Slides for Java do projektu. Aspose.Slides for Java je publikováno v Maven repozitáři společnosti Aspose, nikoli v Maven Central, takže Maven projekt musí deklarovat tento repozitář. Můžete také stáhnout soubor JAR a umístit jej ručně na classpath. Oba způsoby končí krátkým programem, který potvrzuje, že knihovna funguje.

Aspose.Slides for Java nevyžaduje Microsoft PowerPoint. Programově generuje potřebné soubory prezentací. Pro zobrazení vygenerovaných prezentací však můžete potřebovat Microsoft PowerPoint nebo jiný prohlížeč prezentací.

## **Požadavky**

- Java Development Kit (JDK). Projekt a příkazy v tomto článku vyžadují JDK 11 nebo novější. U JDK 11 program kontrolující instalaci vypíše varování začínající „WARNING: An illegal reflective access operation has occurred“; nemá vliv na výsledek a lze jej ignorovat.
- [Apache Maven](https://maven.apache.org/install.html), pokud používáte Maven cestu.
- V Linuxu knihovna fontconfig a alespoň jeden nainstalovaný font. Viz [Linux](#linux).

## **Instalace z Maven repozitáře**

Aspose hostuje své Java knihovny ve vlastním [Maven repozitáři](https://releases.aspose.com/java/repo/com/aspose/). Pro použití [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) v Maven projektu přidejte dvě položky do souboru *pom.xml*.

1. **Deklarujte Aspose Maven repozitář.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Přidejte závislost Aspose.Slides for Java.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

Classifikátor `jdk16` je vyžadován: vybírá build knihovny pro Java SE. Nahraďte `26.9` nejnovější verzí uvedenou v [repozitáři](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Repo publikují soubor SHA‑1 kontrolního součtu vedle každého JAR, který Maven zkontroluje při stažení knihovny.

### **Zkontrolujte instalaci**

Pro kontrolu nastavení s novým projektem:

1. Vytvořte složku pro projekt a uložte do ní tento *pom.xml*:

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
       </properties>

       <repositories>
           <repository>
               <id>AsposeJavaAPI</id>
               <name>Aspose Java API</name>
               <url>https://releases.aspose.com/java/repo/</url>
           </repository>
       </repositories>

       <dependencies>
           <dependency>
               <groupId>com.aspose</groupId>
               <artifactId>aspose-slides</artifactId>
               <version>26.9</version>
               <classifier>jdk16</classifier>
           </dependency>
       </dependencies>

       <build>
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   Kromě repozitáře a závislosti tento *pom.xml* nastavuje verzi Java, kterou se má kompilovat, určuje třídu, kterou spustí `mvn exec:java`, a upíná plugin kompilátoru, protože starší plugin používaný v některých Maven instalacích ignoruje nastavení `maven.compiler.release`.

2. Uložte první příklad z [Create Presentations](/slides/cs/java/create-presentation/) jako *src/main/java/HelloSlides.java*.

3. Ve složce projektu spusťte:

   ```bash
   mvn compile exec:java
   ```

Maven stáhne Aspose.Slides for Java, zkompiluje program a spustí jej. Program uloží *new_presentation.pptx* do složky projektu.

## **Použijte soubor JAR bez Maven**

1. Stáhněte *aspose-slides-26.9-jdk16.jar* ze [složky verze](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) v repozitáři. Pro jinou verzi otevřete její složku v [repozitáři](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) a stáhněte soubor končící na *-jdk16.jar*.
2. Uložte první příklad z [Create Presentations](/slides/cs/java/create-presentation/) jako *HelloSlides.java* do stejné složky, kde je soubor JAR.
3. V této složce spusťte:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

JDK zkompiluje a spustí jediný zdrojový soubor a program uloží *new_presentation.pptx* do složky. Ve vlastní aplikaci přidejte soubor JAR do classpath ve vašem build nástroji nebo IDE.

## **Linux**

Aspose.Slides for Java používá podporu fontů v Javě, která v Linuxu vyžaduje knihovnu fontconfig a alespoň jeden nainstalovaný font. Bez nich selže ukládání prezentace s chybou „Fontconfig head is null, check your fonts or fonts configuration“. Minimální serverové a kontejnerové obrazy mohou obojí postrádat; například oficiální Ubuntu kontejnerový obraz neobsahuje žádný z nich.

Na Debianu a Ubuntu tento příkaz nainstaluje JDK, Maven, fontconfig a fonty DejaVu:

```bash
   sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Fonty použité ve vašich prezentacích, nebo vhodné náhrady, musí být také nainstalovány, aby se text správně vykreslil.

## **FAQ**

### Jak mohu ověřit, že je Aspose.Slides integrován správně?

Sestavte projekt, vytvořte prázdnou [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) a uložte ji pod novým názvem. Pokud je soubor vytvořen bez vyhození výjimek, knihovna byla úspěšně integrována.

### Jak mohu omezit spotřebu paměti při zpracování velkých prezentací?

Zvyšte limity paměti JVM jen tolik, kolik je potřeba, a v `finally` bloku zavolejte [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) na každou instanci [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), aby se cache okamžitě uvolnila. Tím se zabrání chybám z nedostatku paměti a udržuje se předvídatelná celková spotřeba paměti během dávkových operací.

### Mohu vyloučit nechtěné exportní formáty a tím zmenšit výslednou velikost JAR?

Aktuální vydání Aspose.Slides jsou distribuována jako jedna monolitická knihovna, takže konkrétní exportéry, jako PDF nebo SVG, nelze při sestavování vypnout.