---
title: Aspose.Slides for Android via Java 설치
type: docs
weight: 90
url: /ko/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- Aspose.Slides 설치
- Aspose.Slides 다운로드
- Aspose.Slides 사용
- Aspose.Slides 설치
- Gradle
- Maven 리포지토리
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 Gradle을 사용하여 Aspose의 Maven 리포지토리에서 Android Studio 프로젝트에 추가하거나, JAR 파일을 수동으로 추가합니다."
---
## **개요**

이 문서는 Aspose.Slides for Android via Java를 Android 프로젝트에 추가하는 방법을 설명합니다. 권장 방법은 Gradle이 Aspose의 Maven 리포지터리에서 라이브러리를 다운로드하도록 하는 것입니다. 또한 JAR 파일을 직접 다운로드하여 프로젝트에 수동으로 추가할 수도 있습니다.

이 라이브러리는 Maven Central이나 Google의 Maven 리포지터리에 게시되지 않았습니다. `aspose-slides` 아티팩트와 `android.via.java` 분류자를 사용하여 Aspose 자체 리포지터리에서 사용할 수 있습니다.

## **Aspose Maven 리포지터리에서 설치**

### **단계 1: 리포지터리 추가**

새 Android Studio 프로젝트는 *settings.gradle.kts*의 `dependencyResolutionManagement` 블록에 리포지터리를 선언하며, Gradle은 모듈 빌드 파일이 추가한 리포지터리를 거부합니다. 두 번째 `dependencyResolutionManagement` 블록을 붙여넣지 말고 기존 블록 내부의 `repositories` 블록에 아래에 표시된 `maven` 라인을 추가하세요:

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

### **단계 2: 의존성 추가**

앱 모듈의 빌드 파일인 *app/build.gradle.kts*의 `dependencies` 블록에 라이브러리를 추가합니다:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

좌표의 마지막 부분인 `android.via.java`는 라이브러리의 Android 빌드를 선택하는 분류자입니다. 이 분류자가 없으면 Gradle이 아티팩트를 찾을 수 없습니다.

그런 다음 Gradle 파일과 프로젝트를 동기화하여 Gradle이 라이브러리를 다운로드하도록 합니다.

### **버전 선택**

Aspose.Slides for Android via Java는 리포지터리의 모든 버전에 대해 빌드되지 않습니다. 해당 빌드는 일부 Aspose.Slides for Java 버전에만 제공되며, Android 빌드가 없는 버전은 해결되지 못합니다. [Aspose.Slides for Android via Java 다운로드 페이지](https://releases.aspose.com/slides/ko/androidjava/)에 나열된 버전 중에서 선택하세요.

### **Groovy 빌드 스크립트**

프로젝트가 Groovy 빌드 스크립트를 사용하는 경우, 기존 `dependencyResolutionManagement` 블록의 *settings.gradle* 안에 있는 `repositories` 블록에 `maven` 라인을 추가하세요:

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

그리고 *app/build.gradle*에 의존성을 추가합니다:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **JAR 파일을 수동으로 추가**

Maven 리포지터리를 사용할 수 없는 경우, JAR 파일을 프로젝트에 추가합니다:

1. [Aspose Maven 리포지터리](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)에서 해당 버전 폴더의 JAR 파일을 다운로드합니다. 버전 26.9의 경우 파일은 *26.9* 폴더에 있는 *aspose-slides-26.9-android.via.java.jar*입니다.
1. 파일을 프로젝트의 *app/libs* 폴더에 복사합니다. 폴더가 없으면 생성하세요.
1. *app/build.gradle.kts*의 `dependencies` 블록에 파일을 추가하고, 프로젝트를 동기화합니다:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **첫 번째 프레젠테이션 만들기**

프로젝트가 동기화된 후, [프레젠테이션 만들기](/slides/ko/androidjava/create-presentation/)를 계속 진행합니다. 첫 번째 예제에서는 슬라이드에 텍스트 상자를 추가하고 프레젠테이션을 앱의 개인 저장소에 저장합니다. 이는 저장소 권한이 필요하지 않습니다. 라이선스가 없으면 Aspose.Slides가 저장하는 모든 슬라이드에 평가용 워터마크를 추가합니다; 자세히 보려면 [라이선스](/slides/ko/androidjava/licensing/)를 참고하세요.

## **버전 관리**

2018년 이후 Aspose.Slides for Android via Java의 버전 관리 방식은 Aspose.Slides for Java와 동일합니다. Android 빌드는 모든 Java 버전에 대해 게시되지 않으며, 자세한 내용은 [버전 선택](#choose-a-version)을 참조하세요.

## **FAQ**

### Aspose.Slides가 올바르게 통합되었는지 어떻게 확인할 수 있나요?

프로젝트를 빌드하고 빈 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/)을 인스턴스화한 뒤 새 이름으로 저장합니다. 예외가 발생하지 않고 파일이 생성되면 라이브러리가 성공적으로 통합된 것입니다.

### 대용량 프레젠테이션을 처리할 때 메모리 사용량을 어떻게 제한할 수 있나요?

각 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 인스턴스에 대해 `finally` 블록에서 [dispose](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#dispose--) 메서드를 호출하여 즉시 리소스를 해제하고, 한 번에 하나의 대용량 프레젠테이션만 처리하세요. 이는 메모리 부족 오류를 방지하고 배치 작업 중 전체 메모리 사용량을 예측 가능하게 유지하는 데 도움이 됩니다.

### 최종 JAR 크기를 줄기 위해 원하지 않는 출력 형식을 제외할 수 있나요?

현재 Aspose.Slides 릴리스는 단일 단일 라이브러리로 제공되므로, 빌드 시 PDF나 SVG와 같은 특정 Exporter를 비활성화할 수 없습니다.