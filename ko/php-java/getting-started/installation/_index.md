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
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 빠르게 설치하세요. 단계별 가이드, 시스템 요구 사항 및 코드 샘플을 제공하며—오늘 바로 PowerPoint 프레젠테이션 작업을 시작하세요!"
---
## **개요**

이 문서에서는 Aspose.Slides for PHP via Java을 설치하고 구성하는 방법을 설명합니다. 필요한 환경 설정, Packagist를 통한 라이브러리 다운로드, PHP/Java Bridge와 함께 Apache Tomcat 구성, 설치 확인을 위한 예제 실행을 다룹니다.

## **환경 구성**

1. PHP 7을 설치하고, PHP 경로를 시스템 `PATH` 변수에 추가한 다음 `php.ini` 파일에서 `allow_url_include`를 `On`으로 설정합니다.
1. JRE 8을 설치합니다. 설치된 JRE의 경로를 `JAVA_HOME` 환경 변수에 설정합니다.
1. Apache Tomcat 8.0을 설치합니다.

## **Aspose.Slides for PHP via Java 다운로드**

`packagist`는 [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides)를 다운로드하는 가장 쉬운 방법입니다.  

Aspose.Slides를 Packagist를 사용해 설치하려면 다음 명령을 실행하십시오:
   ```bash
   composer require aspose/slides
   ```

## **Apache Tomcat 구성**

1. http://php-java-bridge.sourceforge.net/pjb/download.php 에서 PHP/Java Bridge(`php-java-bridge_x.x.x_documentation.zip`)를 다운로드하고 `JavaBridge.war` 파일을 Tomcat `webapps` 폴더에 추출합니다.
1. Apache Tomcat 서비스를 시작합니다.
1. [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/ko/php-java)를 다운로드하여 `aspose.slides` 폴더에 추출합니다. `jar/aspose-slides-x.x-php.jar` 파일을 `webapps\JavaBridge\WEB-INF\lib` 폴더에 복사합니다. **PHP 8**을 사용하는 경우, PHP-Java Bridge의 원본 `Java.inc`를 `Java.inc.php8.zip`에 포함된 `Java.inc`로 교체합니다.
1. Apache Tomcat 서비스를 다시 시작합니다.
1. `aspose.slides` 폴더에서 `example.php`를 실행하여 다음 명령으로 예제를 실행합니다:
   ```bash
   php example.php
   ```

## **FAQ**

**Aspose.Slides가 올바르게 통합되었는지 어떻게 확인할 수 있나요?**  
프로젝트를 빌드하고 빈 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/)을 인스턴스화한 뒤 새 이름으로 저장합니다. 예외가 발생하지 않고 파일이 생성되면 라이브러리가 성공적으로 통합된 것입니다.

**대용량 프레젠테이션을 처리할 때 메모리 사용량을 어떻게 제한할 수 있나요?**  
필요한 수준까지만 JVM 메모리 제한을 높이고, 각 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 인스턴스를 `finally` 블록에서 닫아 캐시를 즉시 해제합니다. 이렇게 하면 메모리 부족 오류를 방지하고 배치 작업 중 전체 메모리 사용량을 예측 가능하게 유지할 수 있습니다.

**불필요한 내보내기 형식을 제외하여 최종 JAR 크기를 줄일 수 있나요?**  
현재 Aspose.Slides 릴리스는 단일 거대한 라이브러리로 제공되므로, 빌드 시 PDF 또는 SVG와 같은 특정 내보내기 기능을 비활성화할 수 없습니다.