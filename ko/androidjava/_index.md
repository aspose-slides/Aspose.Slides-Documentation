---
title: Aspose.Slides for Android via Java
second_title: Aspose.Slides for Android
type: docs
weight: 40
url: /ko/androidjava/
keywords:
- 문서
- 프레젠테이션 처리
- 프레젠테이션 변환
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "여기에서 시작하십시오: 앱에 Aspose.Slides for Android via Java를 추가하고, 첫 번째 프레젠테이션을 만든 다음, 일반 작업 가이드, API 참조 및 지원 정보를 찾으십시오."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java는 Microsoft PowerPoint 없이 Android 애플리케이션에서 PowerPoint 및 OpenDocument 프레젠테이션을 만들고, 읽고, 편집하고 변환할 수 있는 클래스 라이브러리입니다.

이 라이브러리는 매크로 지원 및 템플릿 변형을 포함한 PPT, PPTX, PPS, POT 및 ODP 파일을 로드하고 저장하며, PDF, XPS, HTML, SVG, TIFF, Markdown 및 이미지 형식으로 내보낼 수 있습니다.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>시작하기</b></p>
<hr>
<p>시작 안내</p>
<ul>
<li><a href="/slides/ko/androidjava/install-aspose-slides-for-android-via-java/">설치</a></li>
<li><a href="/slides/ko/androidjava/create-presentation/">첫 프레젠테이션 만들기</a></li>
<li><a href="/slides/ko/androidjava/getting-started/">시작 가이드</a></li>
</ul>
<p>평가</p>
<ul>
<li><a href="/slides/ko/androidjava/supported-file-formats/">지원 파일 형식</a></li>
<li><a href="/slides/ko/androidjava/evaluate-aspose-slides/">평가판 제한 사항</a></li>
<li><a href="/slides/ko/androidjava/licensing/">라이선스</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides로 빌드</b></p>
<hr>
<p>일반 작업</p>
<ul>
<li><a href="/slides/ko/androidjava/open-presentation/">프레젠테이션 열기</a></li>
<li><a href="/slides/ko/androidjava/save-presentation/">프레젠테이션 저장</a></li>
<li><a href="/slides/ko/androidjava/convert-powerpoint-to-pdf/">PDF로 변환</a></li>
<li><a href="/slides/ko/androidjava/convert-slide/">슬라이드를 이미지로 렌더링</a></li>
<li><a href="/slides/ko/androidjava/manage-text/">텍스트와 도형 편집</a></li>
</ul>
<p>Slides 워크플로우</p>
<ul>
<li><a href="/slides/ko/androidjava/powerpoint-charts/">차트</a></li>
<li><a href="/slides/ko/androidjava/powerpoint-animation/">애니메이션</a></li>
<li><a href="/slides/ko/androidjava/manage-media-files/">오디오 및 비디오</a></li>
<li><a href="/slides/ko/androidjava/presentation-design/">슬라이드 디자인</a></li>
<li><a href="/slides/ko/androidjava/merge-presentation/">프레젠테이션 병합</a></li>
</ul>
<p>예제</p>
<ul>
<li><a href="/slides/ko/androidjava/examples/">슬라이드 요소별 예제</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>참조 및 지원</b></p>
<hr>
<p>참조</p>
<ul>
<li><a href="https://reference.aspose.com/slides/ko/androidjava/">API 참조</a></li>
<li><a href="https://releases.aspose.com/slides/ko/androidjava/release-notes/">릴리스 노트</a></li>
<li><a href="/slides/ko/androidjava/known-issues/">알려진 문제</a></li>
<li><a href="https://releases.aspose.com/slides/ko/androidjava/">다운로드</a></li>
</ul>
<p>지원</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ko/11">무료 지원 포럼</a></li>
<li><a href="https://helpdesk.aspose.com/">유료 지원 헬프데스크</a></li>
</ul>
</div>
</div>

------

## **첫 번째 프레젠테이션**

이 라이브러리는 Aspose의 Maven 저장소에서 제공됩니다. 새 Android Studio 프로젝트에는 이미 *settings.gradle.kts*에 `dependencyResolutionManagement` 블록이 포함되어 있습니다. 두 번째 블록을 붙여넣는 대신 아래에 표시된 `maven` 라인을 해당 블록의 `repositories` 섹션에 추가하십시오:

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

그런 다음 라이브러리를 *app/build.gradle.kts*에 추가하고 프로젝트를 동기화하십시오:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[Installation](/slides/ko/androidjava/install-aspose-slides-for-android-via-java/)은 Groovy 빌드 스크립트, 수동 JAR 파일 및 버전 선택 방법을 다룹니다. 첫 번째 프레젠테이션에 대한 코드는 [Create Presentations](/slides/ko/androidjava/create-presentation/)에 있습니다. 이 코드는 슬라이드에 텍스트 상자를 추가하고 프레젠테이션을 앱의 저장소에 저장합니다. 해당 샘플은 컴파일되어 APK로 빌드되었지만 디바이스에서는 실행되지 않았습니다. 라이선스가 없으면 저장된 프레젠테이션에 평가 워터마크가 표시됩니다 — 자세한 내용은 [Licensing](/slides/ko/androidjava/licensing/)를 참조하십시오.