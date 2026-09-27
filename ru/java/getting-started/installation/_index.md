---
title: Установка
type: docs
weight: 70
url: /ru/java/installation/
keywords:
- установить Aspose.Slides
- скачать Aspose.Slides
- использовать Aspose.Slides
- установка Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Установите Aspose.Slides for Java из Maven‑репозитория Aspose или в виде JAR‑файла, настройте предварительные требования Linux и проверьте установку с помощью первой программы."
---
## **Обзор**

В этой статье объясняется, как добавить Aspose.Slides for Java в проект. Aspose.Slides for Java публикуется в собственном Maven‑репозитории Aspose, а не в Maven Central, поэтому Maven‑проект должен объявить этот репозиторий. Вы также можете скачать JAR‑файл и разместить его в пути к классам вручную. Оба пути завершаются небольшим примером, подтверждающим работу библиотеки.

Aspose.Slides for Java не требует Microsoft PowerPoint. Он программно генерирует необходимые файлы презентаций. Однако для просмотра сгенерированных презентаций может потребоваться Microsoft PowerPoint или другой просмотрщик презентаций.

## **Предварительные требования**

- Java Development Kit (JDK). Для проекта и команд в этой статье требуется JDK 11 или новее. В JDK 11 программа, проверяющая установку, выводит предупреждение, начинающееся с «WARNING: An illegal reflective access operation has occurred»; оно не влияет на результат и может быть проигнорировано.
- [Apache Maven](https://maven.apache.org/install.html), если вы используете путь Maven.
- В Linux требуется библиотека fontconfig и как минимум один установленный шрифт. См. раздел [Linux](#linux).

## **Установка из Maven‑репозитория**

Aspose размещает свои Java‑библиотеки в собственном [Maven‑репозитории](https://releases.aspose.com/java/repo/com/aspose/). Чтобы использовать [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) в Maven‑проекте, добавьте два элемента в ваш *pom.xml*.

1. **Объявите Maven‑репозиторий Aspose.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Добавьте зависимость Aspose.Slides for Java.**

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

Классификатор `jdk16` обязателен: он выбирает сборку библиотеки для Java SE. Замените `26.9` на последнюю версию, указанную в [репозитории](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Репозиторий публикует файл контрольной суммы SHA‑1 рядом с каждым JAR, который Maven проверяет при загрузке библиотеки.

### **Проверка установки**

Чтобы проверить настройку в новом проекте:

1. Создайте папку для проекта и сохраните в неё этот *pom.xml*:

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

   Помимо репозитория и зависимости, этот *pom.xml* задаёт Java‑release для компиляции, указывает класс, который запускает `mvn exec:java`, и фиксирует плагин компилятора, поскольку старый плагин, используемый по умолчанию в некоторых установках Maven, игнорирует параметр `maven.compiler.release`.

2. Сохраните первый пример из раздела [Create Presentations](/slides/ru/java/create-presentation/) как *src/main/java/HelloSlides.java*.

3. В папке проекта выполните:

   ```bash
   mvn compile exec:java
   ```

Maven загрузит Aspose.Slides for Java, скомпилирует программу и запустит её. Программа сохранит *new_presentation.pptx* в папке проекта.

## **Использование JAR‑файла без Maven**

1. Скачайте *aspose-slides-26.9-jdk16.jar* из [папки версии](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) в репозитории. Для другой версии откройте соответствующую папку в [репозитории](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) и скачайте файл, оканчивающийся на *-jdk16.jar*.
2. Сохраните первый пример из раздела [Create Presentations](/slides/ru/java/create-presentation/) как *HelloSlides.java* в той же папке, что и JAR‑файл.
3. В этой папке выполните:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

JDK скомпилирует и запустит единственный исходный файл, а программа сохранит *new_presentation.pptx* в папке. В своём приложении добавьте JAR‑файл в путь к классам вашего инструмента сборки или IDE.

## **Linux**

Aspose.Slides for Java использует поддержку шрифтов Java, которая в Linux требует библиотеку fontconfig и как минимум один установленный шрифт. Без них сохранение презентации завершается ошибкой «Fontconfig head is null, check your fonts or fonts configuration». Минимальные серверные и контейнерные образы могут не содержать ни того, ни другого; например, официальный образ контейнера Ubuntu не имеет ни того, ни другого.

В Debian и Ubuntu эта команда устанавливает JDK, Maven, fontconfig и шрифты DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Шрифты, используемые в ваших презентациях, или подходящие их заменители, также должны быть установлены, чтобы текст отображался корректно.

## **FAQ**

### Как можно проверить, что Aspose.Slides интегрирован корректно?

Соберите проект, создайте пустой [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и сохраните его под новым именем. Если файл создаётся без исключений, библиотека успешно интегрирована.

### Как ограничить потребление памяти при обработке больших презентаций?

Увеличивайте лимиты памяти JVM только настолько, насколько это необходимо, и вызывайте [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) для каждого экземпляра [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) в блоке `finally`, чтобы быстро освобождать кэш. Это предотвращает ошибки «out‑of‑memory» и делает общее использование памяти предсказуемым при пакетных операциях.

### Можно ли исключить ненужные форматы экспорта, чтобы уменьшить окончательный размер JAR?

Текущие выпуски Aspose.Slides поставляются как единственная монолитная библиотека, поэтому отключить отдельные экспортеры, такие как PDF или SVG, во время сборки нельзя.