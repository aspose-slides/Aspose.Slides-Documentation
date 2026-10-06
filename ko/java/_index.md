---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
type: docs
weight: 20
url: /ko/java/
keywords:
- 문서
- 프레젠테이션 처리
- 프레젠테이션 변환
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "시작하기: Aspose.Slides for Java를 설치하고, 첫 번째 프레젠테이션을 만든 다음, 일반 작업, 배포 및 API 참조에 대한 가이드를 찾아보세요."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java은 Microsoft PowerPoint 없이 Java 애플리케이션에서 PowerPoint 및 OpenDocument 프레젠테이션을 생성, 읽기, 편집 및 변환하는 클래스 라이브러리입니다.

PPT, PPTX, PPS, POT 및 ODP를 매크로 사용 가능 및 템플릿 변형을 포함하여 로드하고 저장하며, PDF, XPS, HTML, SVG, TIFF, Markdown 및 이미지 형식으로 내보냅니다.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>시작하기</b></p>
<hr>
<p>시작하기</p>
<ul>
<li><a href="/slides/ko/java/installation/">설치</a></li>
<li><a href="/slides/ko/java/create-presentation/">첫 프레젠테이션 만들기</a></li>
<li><a href="/slides/ko/java/system-requirements/">시스템 요구 사항</a></li>
<li><a href="/slides/ko/java/getting-started/">시작 가이드</a></li>
</ul>
<p>평가</p>
<ul>
<li><a href="/slides/ko/java/supported-file-formats/">지원 파일 형식</a></li>
<li><a href="/slides/ko/java/features-overview/">기능 개요</a></li>
<li><a href="/slides/ko/java/evaluate-aspose-slides/">체험 제한</a></li>
<li><a href="/slides/ko/java/licensing/">라이선스</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides로 빌드하기</b></p>
<hr>
<p>공통 작업</p>
<ul>
<li><a href="/slides/ko/java/open-presentation/">프레젠테이션 열기</a></li>
<li><a href="/slides/ko/java/save-presentation/">프레젠테이션 저장</a></li>
<li><a href="/slides/ko/java/convert-powerpoint-to-pdf/">PDF로 변환</a></li>
<li><a href="/slides/ko/java/convert-slide/">슬라이드를 이미지로 렌더링</a></li>
<li><a href="/slides/ko/java/manage-text/">텍스트 및 도형 편집</a></li>
</ul>
<p>Slides 워크플로</p>
<ul>
<li><a href="/slides/ko/java/powerpoint-charts/">차트</a></li>
<li><a href="/slides/ko/java/powerpoint-animation/">애니메이션</a></li>
<li><a href="/slides/ko/java/manage-media-files/">오디오 및 비디오</a></li>
<li><a href="/slides/ko/java/presentation-design/">슬라이드 디자인</a></li>
<li><a href="/slides/ko/java/merge-presentation/">프레젠테이션 병합</a></li>
</ul>
<p>예제</p>
<ul>
<li><a href="/slides/ko/java/examples/">슬라이드 요소별 예제</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">GitHub 예제</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>배포 및 지원</b></p>
<hr>
<p>배포</p>
<ul>
<li><a href="/slides/ko/java/system-requirements/#linux">Linux 전제 조건</a></li>
<li><a href="/slides/ko/java/how-to-run-aspose-slides-in-docker/">Docker에서 실행</a></li>
<li><a href="/slides/ko/java/deploy-fonts/">글꼴</a></li>
<li><a href="/slides/ko/java/security/">보안</a></li>
</ul>
<p>참조</p>
<ul>
<li><a href="https://reference.aspose.com/slides/ko/java/">API 참조</a></li>
<li><a href="https://releases.aspose.com/slides/ko/java/release-notes/">릴리스 노트</a></li>
<li><a href="/slides/ko/java/known-issues/">알려진 문제</a></li>
<li><a href="/slides/ko/java/api-limitations/">출력 메타데이터 제한</a></li>
<li><a href="https://releases.aspose.com/slides/ko/java/">다운로드</a></li>
</ul>
<p>지원</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ko/11">무료 지원 포럼</a></li>
<li><a href="https://helpdesk.aspose.com/">유료 지원 헬프데스크</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **첫 번째 프레젠테이션**

Aspose.Slides for Java은 Aspose 자체 Maven 저장소에 게시되어 있으며 Maven Central에는 없습니다. Maven 프로젝트용 폴더를 만들고 그 안에 *pom.xml*을 저장하십시오. 이 파일은 저장소를 선언하고 라이브러리를 추가하며 실행할 클래스를 지정합니다:

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

이 코드를 *src/main/java/HelloSlides.java*에 저장하십시오:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // 프레젠테이션을 생성합니다. 이미 빈 슬라이드가 하나 포함되어 있습니다.
        Presentation presentation = new Presentation();
        try {
            // 첫 번째 슬라이드를 가져옵니다.
            ISlide slide = presentation.getSlides().get_Item(0);

            // 구름 모양을 추가하고 그 안에 텍스트를 넣습니다.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // 프레젠테이션을 PPTX 파일로 저장합니다.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

그 후, JDK 11 이상 및 Apache Maven이 설치된 상태에서 프로젝트 폴더에서 다음 명령을 실행하십시오:

```bash
mvn compile exec:java
```

프로그램은 프로젝트 폴더에 *new_presentation.pptx* 파일을 저장하며, 이 파일은 텍스트가 포함된 구름 모양의 슬라이드 하나를 갖습니다. Linux에서는 fontconfig와 최소 하나의 글꼴이 설치되어 있어야 합니다; 자세히는 [Installation](/slides/ko/java/installation/#linux) 를 참조하십시오. 라이선스가 없으면 저장된 파일에 평가 워터마크가 포함됩니다 — 자세히는 [Licensing](/slides/ko/java/licensing/) 를 참고하십시오. 프레젠테이션을 만들고 채우는 더 많은 방법은 [Create Presentations](/slides/ko/java/create-presentation/) 를 확인하십시오.