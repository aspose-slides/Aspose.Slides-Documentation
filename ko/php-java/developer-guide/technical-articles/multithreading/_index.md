---
title: Aspose.Slides for PHP via Java의 멀티스레딩
linktitle: 멀티스레딩
type: docs
weight: 310
url: /ko/php-java/multithreading/
keywords:
- 멀티스레딩
- 다중 스레드
- 병렬 작업
- 슬라이드 변환
- 슬라이드 이미지 변환
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java 멀티스레딩은 PowerPoint 및 OpenDocument 처리 속도를 향상시킵니다. 효율적인 프레젠테이션 워크플로를 위한 모범 사례를 확인하세요."
---
## **소개**

프레젠테이션에 대한 병렬 작업이(구문 분석/로드/클론 제외) 가능하고 대부분 잘 작동하지만(대부분의 경우), 라이브러리를 여러 스레드에서 사용할 때 잘못된 결과가 나올 가능성이 조금 있습니다.

멀티스레드 환경에서 하나의 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 인스턴스를 **사용하지 않** 것을 강력히 권장합니다. 이는 예측할 수 없는 오류나 쉽게 감지되지 않는 실패를 초래할 수 있기 때문입니다.

여러 스레드에서 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 로드, 저장 및/또는 복제하는 것은 **안전하지 않**습니다. 이러한 작업은 **지원되지 않**습니다. 이런 작업을 수행해야 한다면 여러 개의 단일 스레드 프로세스를 사용해 작업을 병렬화해야 하며, 각 프로세스는 자체 프레젠테이션 인스턴스를 사용해야 합니다.

PHP에서 확장을 사용할 때 멀티스레딩을 보장하지 않습니다. 사용한다면 자체 위험을 감수하고 사용하십시오.

## **자주 묻는 질문**

**각 스레드에서 라이선스 설정을 호출해야 합니까?**

아니요. 스레드가 시작되기 전에 프로세스/앱 도메인당 한 번만 수행하면 충분합니다. [license setup](/slides/ko/php-java/licensing/)이 동시에 호출될 수 있는 경우(예: 지연 초기화 중) 해당 호출을 동기화하세요. 라이선스 설정 메서드 자체가 스레드 안전하지 않기 때문입니다.

**스레드 간에 `Presentation` 또는 `Slide` 객체를 전달할 수 있습니까?**

스레드 간에 "live" 프레젠테이션 객체를 전달하는 것은 권장되지 않습니다. 스레드마다 독립적인 인스턴스를 사용하거나 각 스레드용으로 별도의 프레젠테이션/슬라이드 컨테이너를 미리 생성하세요. 이 방법은 단일 프레젠테이션 인스턴스를 스레드 간에 공유하지 말라는 일반적인 권고를 따릅니다.

**각 스레드가 자체 `Presentation` 인스턴스를 갖는 경우, PDF, HTML, 이미지와 같은 다양한 형식으로의 내보내기를 병렬화해도 안전합니까?**

예. 독립적인 인스턴스와 별도의 출력 경로를 사용하면 이러한 작업은 일반적으로 올바르게 병렬화됩니다. 공유 프레젠테이션 객체와 공유 I/O 스트림을 피하십시오.

**멀티스레딩 환경에서 전역 폰트 설정(폴더, 대체 등)을 어떻게 해야 하나요?**

스레드를 시작하기 전에 모든 전역 [font settings](/slides/ko/php-java/powerpoint-fonts/)을 초기화하고, 병렬 작업 중에는 변경하지 마십시오. 이렇게 하면 공유 폰트 리소스에 대한 경쟁 조건을 제거할 수 있습니다.