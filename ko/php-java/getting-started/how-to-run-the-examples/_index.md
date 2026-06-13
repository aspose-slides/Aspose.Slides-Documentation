---
title: 예제 실행 방법
type: docs
weight: 140
url: /ko/php-java/how-to-run-the-examples/
keywords:
- 예제
- 소프트웨어 요구 사항
- GitHub
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java 예제를 빠르게 실행하십시오: 저장소를 복제하고, 패키지를 복원한 다음, PPT, PPTX 및 ODP 기능을 빌드하고 테스트합니다."
---
## **GitHub에서 다운로드**
Aspose.Slides for PHP via Java의 모든 예제는 [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java)에 호스팅되어 있습니다. 원하는 Github 클라이언트를 사용해 저장소를 복제하거나 [여기](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master)에서 ZIP 파일을 다운로드할 수 있습니다.

ZIP 파일의 내용을 컴퓨터의 원하는 폴더에 압축 해제하십시오. 모든 예제는 **Examples** 폴더에 있습니다.

![todo:image_alt_text](examples_directory.png)

## **IDE에 예제 가져오기**
이 프로젝트는 Maven 빌드 시스템을 사용합니다. 최신 IDE라면 프로젝트와 종속성을 쉽게 열거나 가져올 수 있습니다. 아래에서는 인기 있는 IDE를 사용해 예제를 빌드하고 실행하는 방법을 보여줍니다.

### **IntelliJ IDEA**
**File** 메뉴를 클릭하고 **Open**를 선택하십시오. 프로젝트 폴더로 이동하여 **pom.xml** 파일을 선택합니다.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

프로젝트가 열리며 종속성을 자동으로 다운로드합니다. **Project** 탭에서 **src/main/java** 폴더의 예제를 찾아보세요. 예제를 실행하려면 파일을 마우스 오른쪽 버튼으로 클릭하고 “Run ..”를 선택하면 예제가 실행되고 출력이 내장 콘솔 창에 표시됩니다.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
**File** 메뉴를 클릭하고 **Import**를 선택하십시오. **Maven** - **Existing Maven Projects**를 선택합니다.

![todo:image_alt_text](eclipse_import.png)

클론하거나 GitHub에서 다운로드한 폴더로 이동하여 **pom.xml** 파일을 선택합니다. 프로젝트가 열리며 종속성을 자동으로 다운로드합니다. **Package Explorer** 탭에서 **src/main/java** 폴더의 예제를 찾아보세요. 예제를 실행하려면 파일을 마우스 오른쪽 버튼으로 클릭하고 **Run As** - **Java Application**을 선택하면 예제가 실행되고 출력이 내장 콘솔 창에 표시됩니다.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
**File** 메뉴를 클릭하고 **Open Project**를 선택하십시오. 클론하거나 GitHub에서 다운로드한 폴더로 이동합니다. **Examples** 폴더 아이콘이 Maven 프로젝트임을 표시합니다. **Examples**를 선택하고 열어 주세요.

![todo:image_alt_text](netbeans_openproject.png)

프로젝트가 열리며 종속성을 자동으로 다운로드합니다. **Projects** 탭에서 **source packages**에 있는 예제를 찾아보세요. 예제를 실행하려면 파일을 마우스 오른쪽 버튼으로 클릭하고 **Run File**을 선택하면 예제가 실행되고 출력이 내장 콘솔 창에 표시됩니다.

![todo:image_alt_text](netbeans_run_example.png)

## **Maven 로컬 저장소에 Aspose.Slides 라이브러리 추가**
IDE에 **Aspose.Slides Examples** 프로젝트를 가져오면 Maven이 자동으로 [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/)에서 aspose.slides JAR 파일을 다운로드합니다. 인터넷에 접근할 수 없는 경우 JAR 파일을 로컬 저장소에 수동으로 추가할 수 있습니다.

### **mvn install**
[aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/)를 다운로드하고 압축을 푼 뒤, aspose.slides-version.jar 파일을 예를 들어 C 드라이브에 복사합니다. 다음 명령을 실행하십시오:

```php

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```php

```

이제 **aspose.slides** JAR 파일이 Maven 로컬 저장소에 복사되었습니다.

### **pom.xml**
설치가 끝난 후 **aspose.slides** 좌표를 pom.xml에 선언하면 됩니다. **repositories** 섹션에 다음 저장소를 추가하고 **dependencies** 섹션에 종속성을 추가하십시오.

```xml
<repository>
    <id>aspose-maven-repository</id>
    <url>http://repository.aspose.com/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>18.6</version>
    <classifier>jdk16</classifier>
</dependency>
```php

### **Done**
빌드하면 이제 **aspose.slides** JAR 파일을 Maven 로컬 저장소에서 가져올 수 있습니다.

## **Contribute**
예제를 추가하거나 개선하고 싶다면 프로젝트에 기여해 주세요. 이 저장소의 모든 예제와 쇼케이스 프로젝트는 오픈 소스이며 여러분의 애플리케이션에서 자유롭게 사용할 수 있습니다.

기여하려면 저장소를 포크하고, 소스 코드를 수정한 뒤 Pull Request를 제출하면 됩니다. 우리는 변경 사항을 검토하고 유용하다고 판단되면 저장소에 반영합니다.