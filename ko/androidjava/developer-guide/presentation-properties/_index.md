---
title: Android에서 프레젠테이션 속성 관리
linktitle: 프레젠테이션 속성
type: docs
weight: 70
url: /ko/androidjava/presentation-properties/
keywords:
- PowerPoint 속성
- 프레젠테이션 속성
- 문서 속성
- 내장 속성
- 맞춤 속성
- 고급 속성
- 속성 관리
- 속성 수정
- 문서 메타데이터
- 메타데이터 편집
- 교정 언어
- 기본 언어
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java에서 프레젠테이션 속성을 완벽히 관리하고 PowerPoint 및 OpenDocument 파일의 검색, 브랜딩 및 워크플로우를 효율화합니다."
---
## **소개**

Aspose.Slides for Android via Java는 **내장** 및 **맞춤** 문서 속성을 지원합니다. 이러한 속성을 사용하여 작성자, 제목 및 사용자 정의 값과 같은 프레젠테이션 메타데이터를 읽고 업데이트할 수 있습니다.

Aspose.Slides를 사용하면 [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) 인터페이스를 통해 프레젠테이션 문서 속성을 처리할 수 있습니다. 이 인터페이스의 인스턴스는 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--)에서 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides는 프레젠테이션을 저장할 때 애플리케이션 및 제작자 메타데이터를 관리합니다; 이러한 필드는 출력물을 만든 소프트웨어를 식별합니다.
{{% /alert %}}

## **프레젠테이션 속성 관리**

문서 속성은 프레젠테이션 콘텐츠와 함께 설명 정보를 저장합니다. 두 가지 범주로 나뉩니다:

- **내장 속성**은 제목, 작성자 및 문서 통계와 같은 표준 메타데이터를 포함합니다.
- **맞춤 속성**은 사용자 정의 이름/값 쌍을 저장합니다.

Aspose.Slides for Android via Java는 두 범주에 대한 액세스를 제공합니다. PowerPoint에서 **File → Info → Properties → Advanced Properties**를 선택하면 문서 메타데이터를 확인할 수 있습니다. 대화 상자는 정보를 **Summary**, **Statistics**, **Contents**, **Custom**과 같은 탭으로 구분합니다. **Custom** 탭을 사용하여 사용자 정의 속성을 관리합니다.

## **암호화된 프레젠테이션에서 공개 속성 읽기**

열기 비밀번호는 일반적으로 프레젠테이션 콘텐츠와 문서 속성을 모두 보호합니다. 프레젠테이션을 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-)를 `false` 로 호출한 후 암호화하면 문서 속성은 공개 상태로 유지됩니다. 그런 다음 애플리케이션은 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-)를 `true` 로 호출하여 열기 비밀번호를 제공하지 않고도 공개 메타데이터를 읽을 수 있습니다.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-)는 Aspose.Slides가 로드하는 내용을 제어합니다; 암호를 해독하지는 않습니다. 속성이 암호화에 포함된 경우 비밀번호 없이 로드하면 실패합니다. 프레젠테이션이 암호화되지 않은 경우 이 옵션은 무시되고 전체 프레젠테이션이 로드됩니다.

예제에서는 문서 속성이 공개된 암호화된 프레젠테이션이 필요합니다. [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--)를 통해 로드 모드를 확인하고 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--)를 사용해 내장 속성을 읽습니다:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

이 모드에서는 슬라이드 콘텐츠가 로드되지 않습니다. 슬라이드, 마스터, 레이아웃, 도형, 미디어 및 기타 프레젠테이션 객체를 사용할 수 없습니다. 애플리케이션은 전체 프레젠테이션 객체 모델이 필요한 작업을 수행하기 전에 항상 [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--)를 확인해야 합니다.

{{% alert color="warning" title="Warning" %}}
공개 메타데이터는 작성자 이름, 제목, 주제, 키워드, 회사 정보, 댓글 및 맞춤 값을 노출할 수 있습니다. 민감한 속성은 프레젠테이션과 함께 암호화하십시오. 인덱싱, 분류, 검색 또는 문서 관리 시스템이 비밀번호 없이 접근해야 하는 특정 요구가 있는 경우에만 공개 상태를 유지하십시오.
{{% /alert %}}

## **암호화된 프레젠테이션 속성 업데이트**

암호화된 PPTX 파일에 대해 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-)를 `true` 로 호출한 후 로드된 프레젠테이션은 공개 메타데이터를 읽기 위한 용도입니다. Aspose.Slides는 해당 메타데이터 전용 객체에서 변경된 속성을 저장할 수 없습니다. 공개 속성은 암호화된 프레젠테이션 내부 데이터와 일치해야 하기 때문입니다. 따라서 속성을 업데이트하려면 올바른 열기 비밀번호와 전체 로드가 필요합니다.

예제에서는 공개 문서 속성을 가진 암호화된 PPTX 프레젠테이션과 알려진 열기 비밀번호가 필요합니다. [LoadOptions.setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)으로 전체 프레젠테이션을 열고, 공개 내장 속성을 업데이트한 뒤 저장합니다. 그런 다음 [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--)를 사용해 암호화가 유지되는지 확인하고, 비밀번호 없이 공개 메타데이터를 다시 열어 새로운 값을 검증합니다:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

애플리케이션이 프레젠테이션 콘텐츠를 복호화하거나 로드할 수 없는 경우, 암호화된 PPTX 파일의 공개 속성을 읽기 전용으로 취급해야 합니다.

## **내장 속성 액세스**

[IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/) 인터페이스는 [getAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTitle--), [getCreatedTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCreatedTime--)와 같은 getter 메서드를 통해 내장 메타데이터를 노출합니다. 이 예제는 기존 프레젠테이션을 열어 콘솔에 저장된 메타데이터를 출력합니다. 값은 입력 프레젠테이션에 따라 다르며 일부 필드는 비어 있을 수 있습니다.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

### **버전 번호 및 편집 시간 보고**

폴더에 있는 각 PPTX 파일에 대해 한 줄씩 보고하려면 Android 앱에서 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--)를 호출해 슬라이드를 로드하지 않고 [IDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/)를 읽습니다. Android via Java API는 편집 지속 시간을 밀리초 단위로 반환합니다. 샘플 폴더 경로를 실제 파일 경로로 교체하십시오. 예제는 지속 시간을 시·분·초 형태로 포맷하고, 24시간 이상인 경우 일 수를 포함합니다.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.File;
import java.util.Locale;

File folder = new File("/path/to/presentations");
File[] files = folder.listFiles();
if (files == null) {
    System.out.println("Cannot list files in " + folder);
} else {
    System.out.println("File | RevisionNumber | TotalEditingTime");
    for (File file : files) {
        if (!file.isFile() || !file.getName().toLowerCase(Locale.ROOT).endsWith(".pptx")) {
            continue;
        }
        IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(file.getAbsolutePath());
        IDocumentProperties properties = info.readDocumentProperties();
        long totalSeconds = (long) properties.getTotalEditingTime() / 1000;
        long days = totalSeconds / 86400;
        String time = String.format(Locale.ROOT, "%02d:%02d:%02d", totalSeconds / 3600 % 24, totalSeconds / 60 % 60, totalSeconds % 60);
        String editingTime = days > 0 ? days + "." + time : time;
        System.out.printf(Locale.ROOT, "%s | %d | %s%n", file.getName(), properties.getRevisionNumber(), editingTime);
    }
}
```

1일 2시간 5분이 기록된 프레젠테이션에 대한 보고서 출력 예시는 다음과 같습니다.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getRevisionNumber--)은 값을 읽으며, 애플리케이션은 [setRevisionNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setRevisionNumber-int-)으로 변경할 수 있습니다. 버전 번호만으로는 프레젠테이션이 몇 번 저장되었는지 혹은 버전 기록을 재구성할 수 없습니다.

[getTotalEditingTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getTotalEditingTime--)은 파일에 기록된 편집 지속 시간을 읽습니다. `00:00:00` 값은 실제 편집이 없더라도 저장된 지속 시간이 0임을 의미합니다.

## **내장 속성 수정**

내장 메타데이터를 업데이트하려면 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--)가 반환한 객체의 setter 메서드를 사용합니다. 이 예제는 기존 프레젠테이션을 열고, [setAuthor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), [setManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-)를 호출한 뒤 [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)로 업데이트된 프레젠테이션을 저장합니다. 저장된 PPTX에는 새로운 메타데이터가 포함됩니다.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Android via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **하이퍼링크 기본값 관리**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getHyperlinkBase--)는 상대 하이퍼링크에 대한 문서 수준 기본값을 반환합니다. [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-)를 사용해 변경하거나 지울 수 있습니다. 이는 프레젠테이션과 연결된 파일을 다른 위치로 이동할 때 유용합니다. 개별 하이퍼링크의 [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--)와는 별개이며, 기본값을 변경해도 저장된 링크 주소나 절대 목적지는 수정되지 않습니다.

예제에서는 `target.html` 같은 상대 링크와 `https://example.org/absolute.html` 같은 절대 링크가 포함된 프레젠테이션이 필요합니다. 기존 기본값을 읽고 새 기본 주소를 할당한 뒤 저장 및 재열기로 값을 확인합니다. 그런 다음 빈 문자열로 기본값을 지우고 별도 파일에서 빈 값이 잘 저장됐는지 확인합니다. 예제 기본 주소를 실제 링크 파일 위치에 맞게 교체하십시오.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

두 검증 메시지는 `true` 를 출력해야 합니다. 기본값을 지워도 개별 하이퍼링크 주소는 그대로 유지됩니다.

기본값이 `old` 폴더를 가리킬 때 `target.pptx`에 대한 상대 링크는 `old/target.pptx`를 열었습니다. 기본값을 `new` 폴더로 바꾸고 저장·재열면 동일한 링크가 `new/target.pptx`를 엽니다. 절대 링크는 그대로 동일 파일을 엽니다. 프레젠테이션을 이동하거나 기본값을 바꾸기 전후에 PowerPoint에서 상대 링크를 테스트하십시오.

## **맞춤 프레젠테이션 속성 추가**

맞춤 속성은 내장 필드에 해당하지 않는 메타데이터를 저장합니다. [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) 메서드를 사용하면 속성 이름으로 값을 할당할 수 있습니다. 이 예제는 프레젠테이션을 생성하고 두 개의 텍스트 값과 정수형 버전 값을 추가한 뒤 [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)로 저장합니다. 기존 이름에 값을 할당하면 해당 속성의 값이 교체됩니다.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **맞춤 속성 액세스 및 수정**

이 예제는 맞춤 속성이 포함된 프레젠테이션을 열고 [getCountOfCustomProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--)를 사용해 속성을 반복합니다. [getCustomPropertyName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-)는 0부터 시작하는 인덱스를 받아 [IDocumentProperties.set_Item](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-)으로 사용되는 이름을 반환합니다. 예제는 각 원래 이름과 값을 출력하고, 원래 타입에 관계없이 번호가 매겨진 문자열로 모든 값을 교체한 뒤 변경 사항을 저장합니다. 맞춤 속성이 없으면 루프는 아무 작업도 수행하지 않습니다.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **실시간 예제**

Aspose.Slides API를 사용해 문서 속성을 다루는 방법을 보려면 온라인 앱 [**PowerPoint 메타데이터 보기 및 편집**](https://products.aspose.app/slides/metadata) 을 사용해 보세요:

[![PowerPoint 메타데이터 보기 및 편집](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**프레젠테이션에서 내장 속성을 어떻게 제거할 수 있나요?**

내장 속성은 프레젠테이션의 필수 구성 요소이며 완전히 제거할 수 없습니다. 다만, 해당 속성이 허용하는 경우 값을 변경하거나 빈 문자열로 설정할 수 있습니다.

**이미 존재하는 맞춤 속성을 추가하면 어떻게 되나요?**

이미 존재하는 맞춤 속성을 추가하면 기존 값이 새 값으로 덮어써집니다. 속성을 미리 제거하거나 확인할 필요 없이 Aspose.Slides가 자동으로 값을 업데이트합니다.

**프레젠테이션을 전체 로드하지 않고 속성에 접근할 수 있나요?**

예. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)를 사용한 뒤 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--)를 호출하면 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 인스턴스를 만들지 않고 저장된 문서 메타데이터를 읽을 수 있습니다. 전체 보고 예제와 형식별 제한 사항은 [가벼운 프레젠테이션 인벤토리 구축](/slides/ko/androidjava/examine-presentation/)을 참조하세요.

**열기 비밀번호 없이 암호화된 프레젠테이션의 공개 속성을 읽을 수 있나요?**

예. 프레젠테이션이 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-)를 `false` 로 호출한 뒤 암호화되었고, [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-)를 `true` 로 호출해 로드된 경우에 가능합니다.

**문서 속성 전용 모드에서 암호화된 PPTX 파일을 업데이트할 수 있나요?**

아니요. 공개 속성과 암호화된 속성 데이터는 일관성을 유지해야 하므로, 암호화된 PPTX 파일을 업데이트하려면 올바른 열기 비밀번호를 사용해 전체 프레젠테이션을 로드해야 합니다.