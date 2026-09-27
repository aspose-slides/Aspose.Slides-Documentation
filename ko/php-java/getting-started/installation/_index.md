---
title: 설치
type: docs
weight: 70
url: /ko/php-java/installation/
keywords:
- Aspose.Slides 설치
- Aspose.Slides 다운로드
- Aspose.Slides 사용
- Aspose.Slides 설치
- 윈도우
- 리눅스
- 파워포인트
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Linux와 Windows에서 PHP용 Aspose.Slides via Java를 설치합니다: PHP, Java, Apache Tomcat 및 PHP/Java Bridge를 설정하고, Composer로 패키지를 추가한 후 짧은 스크립트로 설정을 확인합니다."
---
## **개요**

Aspose.Slides for PHP via Java은 두 개의 프로세스에서 실행됩니다. PHP 스크립트는 Aspose.Slides에 대한 모든 호출을 PHP/Java Bridge를 통해 Java에서 실행되는 Aspose.Slides로 전달하는 PHP 클래스를 사용합니다. 이 문서는 양쪽을 설정하고, Composer로 패키지를 설치하며, 설치를 확인하기 위한 간단한 스크립트를 실행하는 방법을 설명합니다.

## **필수 조건**

- **PHP 7.0~8.3**, `php.ini`에 `allow_url_include = On`이 설정되어 있어야 합니다. 스크립트는 Tomcat에서 HTTP를 통해 브리지의 클라이언트 라이브러리 `Java.inc`를 로드합니다. PHP 8.4 이상에서는 `Java.inc`가 PHP의 `xml` 확장이 로드될 때 “end() expects exactly 1 argument” 오류와 함께 중단되며, Windows 빌드 PHP는 항상 이를 로드합니다.
- **[Composer](https://getcomposer.org/)**.
- **Java 8 이상**. JRE만 있어도 됩니다.
- **Apache Tomcat 9**. PHP/Java Bridge는 `javax.servlet` API 위에 구축되었으며, Tomcat 10 이상에서는 해당 API를 제공하지 않아 브리지가 시작되지 않습니다.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1** 최신 릴리스. 이 웹 애플리케이션 `JavaBridge.war`는 Tomcat에서 실행됩니다.

이 문서는 Tomcat과 PHP 스크립트를 동일한 컴퓨터에서 실행하는 것을 전제로 합니다. Aspose.Slides는 Tomcat 내부에서 파일을 열고 저장하므로 스크립트가 전달하는 모든 경로는 Tomcat에서 유효해야 합니다.

## **Linux에 설치**

다음 명령은 Ubuntu 24.04의 홈 폴더에 모든 것을 설치합니다. 다른 배포판에서는 해당 배포판의 패키지 관리자를 사용해 동일한 패키지를 설치하십시오.

1. PHP, Composer, Java 및 다운로드 도구를 설치하고, PHP CLI에서 `allow_url_include`를 켭니다:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

2. Apache Tomcat 9와 PHP/Java Bridge를 다운로드하고, 브리지의 `JavaBridge.war`를 Tomcat의 `webapps` 폴더에 넣은 뒤 Tomcat을 시작합니다. Tomcat은 시작 시 WAR 파일을 `webapps/JavaBridge`에 풀어냅니다:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

3. 프로젝트 폴더를 만들고 [Packagist](https://packagist.org/packages/aspose/slides)에서 Aspose.Slides for PHP via Java를 설치합니다:

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

4. Tomcat을 중지하고, 패키지에서 Aspose.Slides JAR 파일을 브리지의 `WEB-INF/lib` 폴더에 복사한 뒤, 패키지에 포함된 PHP 8용 `Java.inc`로 브리지의 `Java.inc`를 교체하고 Tomcat을 다시 시작합니다:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/ko/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/ko/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   PHP 7을 사용하는 경우 `Java.inc` 교체는 건너뛰세요. Tomcat이 시작되는 데 몇 초가 걸리며, 스크립트가 Aspose.Slides를 사용할 때마다 실행 중이어야 합니다.

## **Windows에 설치**

1. [Windows용 PHP 8.3](https://www.php.net/downloads.php?os=windows)을 설치하고 해당 폴더를 `PATH` 환경 변수에 추가합니다. `php.ini-production`을 동일한 폴더의 `php.ini`로 복사하고, `php.ini`에서 `allow_url_include = On`을 설정한 뒤 `extension_dir = "ext"`, `extension=openssl`, `extension=zip` 라인의 주석을 해제합니다. Composer는 패키지 다운로드에 `openssl`이, 압축 해제에 `zip`이 필요합니다(7‑Zip가 설치되어 있거나 `unzip` 명령이 `PATH`에 있는 경우는 제외).
2. [Composer](https://getcomposer.org/download/)를 설치합니다.
3. Java를 설치하고 `JAVA_HOME` 환경 변수를 해당 폴더로 설정합니다. Tomcat은 이 변수가 없으면 시작되지 않습니다.
4. 명령 프롬프트에서 Apache Tomcat 9와 PHP/Java Bridge를 다운로드하고, 브리지의 `JavaBridge.war`를 Tomcat의 `webapps` 폴더에 넣은 뒤 Tomcat을 시작합니다. Tomcat 스크립트는 `CATALINA_HOME` 변수를 통해 Tomcat을 찾으므로, 다음 단계에서도 동일한 명령 프롬프트 창을 사용하십시오. Tomcat은 시작 시 WAR 파일을 `webapps\JavaBridge`에 풀어냅니다:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

5. 프로젝트 폴더를 만들고 [Packagist](https://packagist.org/packages/aspose/slides)에서 Aspose.Slides for PHP via Java를 설치합니다:

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

6. Tomcat을 중지하고, 패키지에서 Aspose.Slides JAR 파일을 브리지의 `WEB-INF\lib` 폴더에 복사한 뒤, 패키지에 포함된 PHP 8용 `Java.inc`로 브리지의 `Java.inc`를 교체하고 Tomcat을 다시 시작합니다:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   PHP 7을 사용하는 경우 `Java.inc` 교체는 건너뛰세요. Tomcat이 시작되는 데 몇 초가 걸리며, 스크립트가 Aspose.Slides를 사용할 때마다 실행 중이어야 합니다.

## **설치 확인**

프로젝트 폴더에 *hello.php*라는 이름으로 다음 스크립트를 저장합니다. 이 스크립트는 텍스트 상자 하나가 포함된 프레젠테이션을 생성하고 스크립트와 같은 폴더에 저장합니다:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/ko/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

프로젝트 폴더에서 실행합니다:

```bash
php hello.php
```

스크립트는 *hello.pptx*를 생성하며, 텍스트 상자가 있는 슬라이드 하나를 포함합니다. 라이선스가 없으면 슬라이드에 평가 워터마크가 표시됩니다; 자세한 내용은 [Licensing](/slides/ko/php-java/licensing/)를 참고하세요.

스크립트는 `aspose.slides.php`를 직접 포함합니다. Composer 자동 로더는 이 파일에 정의된 클래스를 로드할 수 없기 때문입니다. 또한 `save`에 절대 경로를 전달하는데, 이는 Aspose.Slides가 Tomcat 내부에서 실행되어 상대 경로를 Tomcat의 작업 폴더를 기준으로 해석하기 때문입니다.

## **FAQ**

**Aspose.Slides가 올바르게 통합됐는지 어떻게 확인할 수 있나요?**

[설치 확인](#verify-the-installation) 섹션의 스크립트를 실행하십시오. 오류 없이 *hello.pptx*가 생성되면 PHP, PHP/Java Bridge, Aspose.Slides가 정상적으로 작동하고 있는 것입니다.

**"Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'" 오류가 발생하는 이유는?**

PHP가 Tomcat에서 `Java.inc`를 로드하지 못했습니다. 오류 메시지에 `http://` 래퍼가 비활성화되었다고 나오면 `php.ini`에서 `allow_url_include = On`으로 설정하고, `php --ini` 명령으로 실제 로드되는 파일을 확인하세요. “Connection refused”가 표시되면 Tomcat이 아직 실행되지 않은 것입니다. Tomcat을 시작하거나 몇 초 정도 기다렸다가 다시 시도하십시오.

**대용량 프레젠테이션을 처리할 때 메모리 사용량을 어떻게 제한할 수 있나요?**

JVM 메모리 제한을 필요한 수준으로만 높이고, `finally` 블록에서 각 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 인스턴스를 닫아 캐시를 즉시 해제하십시오. 이렇게 하면 메모리 부족 오류를 방지하고 배치 작업 중 메모리 사용량을 예측 가능하게 유지할 수 있습니다.

**불필요한 내보내기 형식을 제외해 최종 JAR 크기를 줄일 수 있나요?**

현재 Aspose.Slides 릴리스는 단일 모놀리식 라이브러리 형태로 제공되므로, 빌드 시 PDF나 SVG와 같은 특정 내보내기 기능을 비활성화할 수 없습니다.